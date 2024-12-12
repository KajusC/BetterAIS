// File: BetterAIS.Business/Services/AuthenticatorService.cs
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using BetterAIS.Business.Models;
using BetterAIS.Data.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace BetterAIS.Business.Services
{
    public class AuthenticatorService : IAuthenticatorService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IVartotojaiService _vartotojaiService;
        private readonly IRoleRepository _roleRepository;
        private readonly ITokenBlacklistService _tokenBlacklistService;

        public AuthenticatorService(
            JwtSettings jwtSettings,
            IVartotojaiService vartotojaiService,
            IRoleRepository roleRepository,
            ITokenBlacklistService tokenBlacklistService)
        {
            _jwtSettings = jwtSettings;
            _vartotojaiService = vartotojaiService;
            _roleRepository = roleRepository;
            _tokenBlacklistService = tokenBlacklistService;
        }

        public async Task<string> Login(LoginModel loginModel)
        {
            var vartotojas = await _vartotojaiService.GetByIdAsync(loginModel.vidko);
            if (vartotojas == null)
            {
                throw new Exception("Vartotojas nerastas");
            }

            if (!BCrypt.Net.BCrypt.Verify(loginModel.Password, vartotojas.Slaptazodis))
            {
                throw new Exception("Neteisingas slaptažodis");
            }

            var token = await GenerateToken(vartotojas);
            return token;
        }

        public async Task Logout(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var jti = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)?.Value;

            if (!string.IsNullOrEmpty(jti))
            {
                await _tokenBlacklistService.BlacklistTokenAsync(jti, jwtToken.ValidTo);
            }
        }

        public async Task<bool> Verify(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _jwtSettings.Issuer,
                    ValidAudience = _jwtSettings.Audience,
                    ClockSkew = TimeSpan.Zero // Remove delay of token when expire
                }, out SecurityToken validatedToken);

                // Optional: Check if token is blacklisted
                var jwtToken = (JwtSecurityToken)validatedToken;
                var jti = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)?.Value;

                if (!string.IsNullOrEmpty(jti) && await _tokenBlacklistService.IsTokenBlacklistedAsync(jti))
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<string> GenerateToken(VartotojaiDTO vartotojas)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

            var role = await _roleRepository.GetByIdAsync(vartotojas.RoleId);
            if (role == null)
            {
                throw new Exception("Role not found");
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, vartotojas.Vidko),
                    new Claim(ClaimTypes.Role, role.Name),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // Unique identifier
                }),
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.TokenExpiryInHours),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

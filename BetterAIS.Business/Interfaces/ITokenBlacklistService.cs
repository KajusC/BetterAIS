namespace BetterAIS.Business.Interfaces;

public interface ITokenBlacklistService
{
    Task BlacklistTokenAsync(string jti, DateTime expiration);
    Task<bool> IsTokenBlacklistedAsync(string jti);
    Task CleanupExpiredTokensAsync();
}

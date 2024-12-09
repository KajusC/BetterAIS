using System.Text;
using AutoMapper;
using BetterAIS.Business;
using BetterAIS.Business.Interfaces;
using BetterAIS.Business.Models;
using BetterAIS.Business.Services;
using BetterAIS.Data.Context;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace BetterAIS.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var Configuration = builder.Configuration;

            // Enable CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policyBuilder =>
                {
                    policyBuilder.AllowAnyOrigin()
                                 .AllowAnyMethod()
                                 .AllowAnyHeader();
                });
            });

            // Add DbContext
            builder.Services.AddDbContext<BetterAisContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });

            // 1. Bind JwtSettings from appsettings.json
            builder.Services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));

            // 2. Register JwtSettings for DI
            builder.Services.AddSingleton(resolver =>
                resolver.GetRequiredService<IOptions<JwtSettings>>().Value);

            // 3. Register Repositories and Services
            builder.Services.AddScoped<IAuthenticatorService, AuthenticatorService>();
            builder.Services.AddScoped<IVartotojaiService, VartotojaiService>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<ITokenBlacklistService, TokenBlacklistService>();

            // Register other repositories
            builder.Services.AddScoped<IDestytojaiRepository, DestytojaiRepository>();
            builder.Services.AddScoped<IFakultetaiRepository, FakultetaiRepository>();
            builder.Services.AddScoped<IFinansavimoTipaiRepository, FinansavimoTipaiRepository>();
            builder.Services.AddScoped<IKabinetaiRepository, KabinetaiRepository>();
            builder.Services.AddScoped<IModuliaiRepository, ModuliaiRepository>();
            builder.Services.AddScoped<IMoksliniaiLaipsniaiRepository, MoksliniaiLaipsniaiRepository>();
            builder.Services.AddScoped<IPaskaitosRepository, PaskaitosRepository>();
            builder.Services.AddScoped<IPaskaitosKabinetaiRepository, PaskaitosKabinetaiRepository>();
            builder.Services.AddScoped<IPaskaitosTipaiRepository, PaskaitosTipaiRepository>();
            builder.Services.AddScoped<IStudentaiRepository, StudentaiRepository>();
            builder.Services.AddScoped<IVartotojaiRepository, VartotojaiRepository>();
            builder.Services.AddScoped<IPazymiaiRepository, PazymiaiRepository>();
            builder.Services.AddScoped<IStatusaiRepository, StatusaiRepository>();
            builder.Services.AddScoped<IStudentoStatusaiRepository, StudentoStatusaiRepository>();
            builder.Services.AddScoped<IStudijuProgramaRepository, StudijuProgramaRepository>();
            builder.Services.AddScoped<ISuvestineRepository, SuvestineRepository>();
            builder.Services.AddScoped<IUzduotysRepository, UzduotysRepository>();
            builder.Services.AddScoped<IUzsiemimoTipaiRepository, UzsiemimoTipaiRepository>();

            // services
            builder.Services.AddScoped<IFinansavimoTipaiService, FinansavimoTipaiService>();
            builder.Services.AddScoped<IDestytojaiService, DestytojaiService>();
            builder.Services.AddScoped<IMoksliniaiLaispniaiService, MoksliniaiLaipsniaiService>();
            builder.Services.AddScoped<IStudijuProgramaService, StudijuProgramaService>();
            builder.Services.AddScoped<IStudentaiService, StudentaiService>();
            builder.Services.AddScoped<IVartotojaiService, VartotojaiService>();

            // Register AutoMapper
            var mapperConfig = AutoMapperConfig.Initialize();
            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            // 4. Configure Authentication with JWT using injected JwtSettings
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

                    if (string.IsNullOrEmpty(jwtSettings.SecretKey))
                    {
                        throw new ArgumentException("JWT SecretKey is not configured. Please set it in appsettings.json.");
                    }

                    var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        ClockSkew = TimeSpan.Zero // Remove delay of token when expire
                    };
                });

            // Register MemoryCache for TokenBlacklistService
            builder.Services.AddMemoryCache();

            // Add Controllers
            builder.Services.AddControllers();

            // Configure Swagger with JWT Authentication Support
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BetterAIS API", Version = "v1" });

                // Add JWT Authentication to Swagger
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, new string[] { } }
                });
            });

            var app = builder.Build();

            // Configure CORS
            app.UseCors("AllowAll");

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BetterAIS API V1");
                    c.RoutePrefix = string.Empty; // Set Swagger UI at app's root
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthentication(); // Must come before UseAuthorization
            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}

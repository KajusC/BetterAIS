using AutoMapper;
using BetterAIS.Business;
using BetterAIS.Business.Interfaces;
using BetterAIS.Business.Services;
using BetterAIS.Data.Context;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BetterAIS.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<BetterAisContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

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
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IStatusaiRepository, StatusaiRepository>();
            builder.Services.AddScoped<IStudentoStatusaiRepository, StudentoStatusaiRepository>();
            builder.Services.AddScoped<IStudijuProgramaRepository, StudijuProgramaRepository>();
            builder.Services.AddScoped<ISuvestineRepository, SuvestineRepository>();
            builder.Services.AddScoped<IUzduotysRepository, UzduotysRepository>();
            builder.Services.AddScoped<IUzsiemimoTipaiRepository, UzsiemimoTipaiRepository>();

            // services
            builder.Services.AddScoped<IFinansavimoTipaiService, FinansavimoTipaiService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var mapperConfig = AutoMapperConfig.Initialize();
            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(
                    x =>
                    {
                        x.SwaggerEndpoint("/swagger/v1/swagger.json", "BetterAIS API V1");
                    }

                    );


            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}

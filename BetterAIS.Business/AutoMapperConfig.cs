using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterAIS.Data.Models;
using BetterAIS.Business.DTO;
using System.Data;

namespace BetterAIS.Business
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Add your mappings here
                cfg.CreateMap<Destytojai, DestytojaiDTO>().ReverseMap();
                cfg.CreateMap<Fakultetai, FakultetaiDTO>().ReverseMap();
                cfg.CreateMap<Kabinetai, KabinetaiDTO>().ReverseMap();
                cfg.CreateMap<FinansavimoTipai, FinansavimoTipaiDTO>().ReverseMap();
                cfg.CreateMap<MoksliniaiLaipsniai, MoksliniaiLaipsniaiDTO>().ReverseMap();
                cfg.CreateMap<PaskaitosTipai, PaskaitosTipaiDTO>().ReverseMap();
                cfg.CreateMap<Role, RolesDTO>().ReverseMap();
                cfg.CreateMap<Statusai, StatusaiDTO>().ReverseMap();
                cfg.CreateMap<StudentoStatusai, StudentoStatusaiDTO>().ReverseMap();
                cfg.CreateMap<UzsiemimoTipai, UzsiemimoTipaiDTO>().ReverseMap();
                cfg.CreateMap<StudijuPrograma, StudijuProgramaDTO>().ReverseMap();
                cfg.CreateMap<Uzduotys, UzduotysDTO>().ReverseMap();
                cfg.CreateMap<Vartotojai, VartotojaiDTO>()
                    .ForMember(dest => dest.GimimoData,
                               opt => opt.MapFrom(src => src.GimimoData.ToDateTime(TimeOnly.MinValue)))
                    .ReverseMap()
                    .ForMember(dest => dest.GimimoData,
                               opt => opt.MapFrom(src => DateOnly.FromDateTime(src.GimimoData)));
                cfg.CreateMap<Studentai, StudentaiDTO>()
                    .ForMember(dest => dest.Vidko, opt => opt.MapFrom(src => src.VidkoNavigation.Vidko))
                    .ForMember(dest => dest.StudijuPradzia, opt => opt.MapFrom(src => src.StudijuPradzia.ToDateTime(TimeOnly.MinValue)))
                    .ForMember(dest => dest.Statusas, opt => opt.MapFrom(src => src.Statusas))
                    .ForMember(dest => dest.Finansavimas, opt => opt.MapFrom(src => src.Finansavimas))
                    .ForMember(dest => dest.FkProgramosKodas, opt => opt.MapFrom(src => src.FkProgramosKodas))
                    .ForMember(dest => dest.Vardas, opt => opt.MapFrom(src => src.VidkoNavigation.Vardas))
                    .ForMember(dest => dest.Pavarde, opt => opt.MapFrom(src => src.VidkoNavigation.Pavarde))
                    .ForMember(dest => dest.GimimoData, opt => opt.MapFrom(src => src.VidkoNavigation.GimimoData.ToDateTime(TimeOnly.MinValue)))
                    .ForMember(dest => dest.TelefonoNr, opt => opt.MapFrom(src => src.VidkoNavigation.TelefonoNr))
                    .ForMember(dest => dest.ElPastas, opt => opt.MapFrom(src => src.VidkoNavigation.ElPastas))
                    .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.VidkoNavigation.RoleId))
                    // šito neturi būt galima matyt per API --- .ForMember(dest => dest.Slaptazodis, opt => opt.MapFrom(src => src.VidkoNavigation.Slaptazodis))
                    .ReverseMap()
                    .ForMember(dest => dest.StudijuPradzia, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.StudijuPradzia)));

                cfg.CreateMap<Moduliai, ModuliaiDTO>().ReverseMap();
                cfg.CreateMap<Paskaitos, PaskaitosDTO>().ReverseMap();
                cfg.CreateMap<PaskaitosKabinetai, PaskaitosKabinetaiDTO>().ReverseMap();
                cfg.CreateMap<Suvestine, SuvestinesDTO>().ReverseMap();
                cfg.CreateMap<Pazymiai, PazymiaiDTO>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data.ToDateTime(TimeOnly.MinValue))) // DateOnly to DateTime
                .ReverseMap()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.Data))); // DateTime to DateOnly

            });

            return config;
        }

    }
}
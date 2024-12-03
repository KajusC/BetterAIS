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
                cfg.CreateMap<Vartotojai, VartotojaiDTO>().ReverseMap();
                cfg.CreateMap<Destytojai, DestytojaiDTO>().ReverseMap();
                cfg.CreateMap<Studentai, StudentaiDTO>().ReverseMap();
                cfg.CreateMap<Moduliai, ModuliaiDTO>().ReverseMap();
                cfg.CreateMap<Paskaitos, PaskaitosDTO>().ReverseMap();
                cfg.CreateMap<PaskaitosKabinetai, PaskaitosKabinetaiDTO>().ReverseMap();
                cfg.CreateMap<Suvestine, SuvestinesDTO>().ReverseMap();
                cfg.CreateMap<Pazymiai, PazymiaiDTO>().ReverseMap();
            });

            return config;
        }
    }
}
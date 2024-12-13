using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using AutoMapper;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;
using BetterAIS.Data.Repositories;

namespace BetterAIS.Business.Services
{
    public class DestytojaiService : IDestytojaiService
    {
        private readonly IDestytojaiRepository _repository;
        private readonly IVartotojaiRepository _repositoryUsers;
        private readonly IModuliaiRepository _moduliaiRepository;
        private readonly IMapper _mapper;
        private readonly IVartotojaiService _vartotojaiService;

        public DestytojaiService(IDestytojaiRepository repository, IVartotojaiService vartotojaiService, IMapper mapper)
        {
            _repository = repository;
            _vartotojaiService = vartotojaiService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DestytojaiDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DestytojaiDTO>>(entities);
        }

        public async Task<DestytojaiDTO> GetByIdAsync(string vidko)
        {
            var entity = await _repository.GetByIdAsync(vidko);
            return _mapper.Map<DestytojaiDTO>(entity);
        }

        public async Task AddAsync(DestytojaiDTO destytojaiModel)
        {
            var vartotojaiModel = new VartotojaiDTO
            {
                Vidko = destytojaiModel.Vidko,
                Slaptazodis = destytojaiModel.Slaptazodis,
                Vardas = destytojaiModel.Vardas,
                GimimoData = destytojaiModel.GimimoData,
                Pavarde = destytojaiModel.Pavarde,
                ElPastas = destytojaiModel.ElPastas,
                TelefonoNr = destytojaiModel.TelefonoNr,
                RoleId = destytojaiModel.RoleId
            };

            await _vartotojaiService.AddDestytojaiVartotojas(vartotojaiModel, destytojaiModel);
        }

        public async Task UpdateAsync(DestytojaiDTO destytojaiModel)
        {

            var entity = _mapper.Map<Destytojai>(destytojaiModel);

            if (entity == null)
            {
                throw new KeyNotFoundException();
            }
            var vartotojaiModel = new VartotojaiDTO
            {
                Vidko = destytojaiModel.Vidko,
                Slaptazodis = destytojaiModel.Slaptazodis,
                Vardas = destytojaiModel.Vardas,
                GimimoData = destytojaiModel.GimimoData,
                Pavarde = destytojaiModel.Pavarde,
                ElPastas = destytojaiModel.ElPastas,
                TelefonoNr = destytojaiModel.TelefonoNr,
                RoleId = destytojaiModel.RoleId
            };

            await _vartotojaiService.UpdateAsync(vartotojaiModel);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(string vidko)
        {
            await _repository.DeleteAsync(vidko);
            await _vartotojaiService.DeleteAsync(vidko);
        }

        public async Task<List<DestytojaiDTO>> GetSuggestedTeachersForModule(string moduleId)
        {
            
            var module = await _moduliaiRepository.GetByIdAsync(moduleId);
            if (module == null) throw new Exception("Module not found");

            
            var allTeachers = await _repository.GetAllAsync();
            if(allTeachers == null) throw new Exception("failed to get all teachers");
            
            var suitableTeachers = new List<DestytojaiDTO>();
            foreach (var teacher in allTeachers)
            {
                //destytojui tenkantys moduliai
                List<Moduliai> modulesForTeacher = await _moduliaiRepository.GetModulesByTeacherIdAsync(teacher.Vidko);
                if (modulesForTeacher == null) throw new Exception("failed to get modules of teacher");

                var totalClassesPerWeek = -1;
                //kiek uzsiemimu tenka destytojui
                totalClassesPerWeek = modulesForTeacher.Sum(m => int.Parse(m.UzsiemimuKiekis));
                if (totalClassesPerWeek < 0) throw new Exception("nesusumuoja destytojo paskaitu");

                // random skaicius
                if (totalClassesPerWeek >= 10) continue;

                // destytojui tenkancios paskaitos
                List<Paskaitos> teacherTimetable = await GetTeacherTimetable(teacher.Vidko);
                if (teacherTimetable == null) throw new Exception("failed to get all classes of teacher");
                //
                if (IsModuleScheduleCompatible(module, teacherTimetable))
                {
                    Console.WriteLine("added suitable");
                    suitableTeachers.Add(_mapper.Map<DestytojaiDTO>(teacher));
                }
            }

            return suitableTeachers;
        }

        private bool IsModuleScheduleCompatible(Moduliai module, List<Paskaitos> teacherSchedule)
        {
            ///modulio paskaitos
            foreach (var moduleSession in module.Paskaitos)
            {
                if (teacherSchedule.Count == 0) { return true;  }
                ///destytojo paskaitos
                foreach (var teacherSession in teacherSchedule)
                {
                    if (moduleSession.Data.Hour == 0 || moduleSession.Trukmė == 0)
                        throw new Exception("Module session time is not properly set");

                    if (teacherSession.Data.Hour == 0 || teacherSession.Trukmė == 0)
                        throw new Exception("Teacher session time is not properly set");
                    // 
                    if (moduleSession.Data.Date == teacherSession.Data.Date &&
                        moduleSession.Data.AddMinutes(moduleSession.Trukmė) > teacherSession.Data &&
                        teacherSession.Data.AddMinutes(teacherSession.Trukmė) > moduleSession.Data)
                    {
                        return false; 
                    }
                }
            }
            return true;
        }

        private async Task<List<Paskaitos>> GetTeacherTimetable(string vidko)
        {
            List<Paskaitos> paskaitos = await _repository.GetTeacherTimetable(vidko);
            return paskaitos;
        }
    }
}

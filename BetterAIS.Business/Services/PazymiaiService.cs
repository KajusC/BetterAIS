using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using AutoMapper;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Business.Services
{
    public class PazymiaiService : IPazymiaiService
    {
        private readonly IPazymiaiRepository _repository;
        private readonly ISuvestineRepository _suvestineRepository;
        private readonly IMapper _mapper;

        public PazymiaiService(IPazymiaiRepository repository, ISuvestineRepository suvestineRepository, IMapper mapper)
        {
            _repository = repository;
            _suvestineRepository = suvestineRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PazymiaiDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PazymiaiDTO>>(entities);
        }

        public async Task<PazymiaiDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Pazymys with ID {id} not found.");
            }
            return _mapper.Map<PazymiaiDTO>(entity);
        }

        public async Task AddAsync(PazymiaiDTO pazymiaiDto)
        {
            var entity = _mapper.Map<Pazymiai>(pazymiaiDto);

            // Ensure the related Suvestine exists if applicable
            if (entity.FkIdSuvestine.HasValue)
            {
                var suvestine = await _suvestineRepository.GetByIdAsync(entity.FkIdSuvestine.Value);
                if (suvestine == null)
                {
                    throw new Exception("Associated Suvestine not found.");
                }
            }

            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(PazymiaiDTO pazymiaiDto)
        {
            var entity = _mapper.Map<Pazymiai>(pazymiaiDto);

            if (entity == null)
            {
                throw new KeyNotFoundException("Pazymys not found for update.");
            }

            if (entity.FkIdSuvestine.HasValue)
            {
                var suvestine = await _suvestineRepository.GetByIdAsync(entity.FkIdSuvestine.Value);
                if (suvestine == null)
                {
                    throw new Exception("Associated Suvestine not found.");
                }
            }

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Pazymys with ID {id} not found.");
            }

            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PazymiaiDTO>> GetGradesByStudentIdAsync(string studentId)
        {
            var grades = await _repository.GetGradesByStudentId(studentId);
            return _mapper.Map<IEnumerable<PazymiaiDTO>>(grades);
        }




        public async Task<double> CalculateWeightedAverage(string studentId)
        {
            var grades = await _repository.GetGradesByStudentId(studentId);

            if (grades == null || !grades.Any())
            {
                throw new Exception("No grades found for the specified student.");
            }

            double totalScore = grades.Sum(grade => grade.Ivertinimas);
            double average = totalScore / grades.Count();

            return average;
        }

    }
}

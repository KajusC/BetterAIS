using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using AutoMapper;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Business.Services
{
    public class PaskaitosService : IPaskaitosService
    {
        private readonly IPaskaitosRepository _repository;
        private readonly IMapper _mapper;

        public PaskaitosService(IPaskaitosRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaskaitosDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PaskaitosDTO>>(entities);
        }

        public async Task<PaskaitosDTO> GetByIdAsync(int id_paskaita)
        {
            var entity = await _repository.GetByIdAsync(id_paskaita);
            return _mapper.Map<PaskaitosDTO>(entity);
        }

        public async Task AddAsync(PaskaitosDTO model)
        {
            var entity = _mapper.Map<Paskaitos>(model);
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(PaskaitosDTO model)
        {
            var entity = _mapper.Map<Paskaitos>(model);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id_paskaita)
        {
            await _repository.DeleteAsync(id_paskaita);
        }

        public Task<PaskaitosDTO> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string modelId)
        {
            throw new NotImplementedException();
        }
    }
}

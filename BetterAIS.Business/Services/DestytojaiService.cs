using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using AutoMapper;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Business.Services
{
    public class DestytojaiService : IDestytojaiService
    {
        private readonly IDestytojaiRepository _repository;
        private readonly IMapper _mapper;

        public DestytojaiService(IDestytojaiRepository repository, IMapper mapper)
        {
            _repository = repository;
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

        public async Task AddAsync(DestytojaiDTO model)
        {
            var entity = _mapper.Map<Destytojai>(model);
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(DestytojaiDTO model)
        {
            var entity = _mapper.Map<Destytojai>(model);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(string vidko)
        {
            await _repository.DeleteAsync(vidko);
        }
    }
}

using AutoMapper;
using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Business.Services;

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
        var paskaitos = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<PaskaitosDTO>>(paskaitos);
    }

    public async Task<PaskaitosDTO> GetByIdAsync(int id)
    {
        var paskaita = await _repository.GetByIdAsync(id);
        return _mapper.Map<PaskaitosDTO>(paskaita);
    }

    public async Task AddAsync(PaskaitosDTO paskaitaDto)
    {
        var paskaita = _mapper.Map<Paskaitos>(paskaitaDto);
        await _repository.AddAsync(paskaita);
    }

    public async Task UpdateAsync(PaskaitosDTO paskaitaDto)
    {
        var paskaita = _mapper.Map<Paskaitos>(paskaitaDto);
        await _repository.UpdateAsync(paskaita);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}

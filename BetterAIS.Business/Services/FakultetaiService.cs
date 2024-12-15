using AutoMapper;
using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;
using BetterAIS.Data.Repositories;

namespace BetterAIS.Business.Services;

public class FakultetaiService : IFakultetaiService
{
    private readonly IFakultetaiRepository _fakultetaiRepository;
    private readonly IMapper _mapper;

    public FakultetaiService(IFakultetaiRepository fakultetaiRepository, IMapper mapper)
    {
        _fakultetaiRepository = fakultetaiRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FakultetaiDTO>> GetAllAsync()
    {
        var fakultetai = await _fakultetaiRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<FakultetaiDTO>>(fakultetai);
    }

    public async Task<FakultetaiDTO> GetByIdAsync(int id)
    {
        var fakas = await _fakultetaiRepository.GetByIdAsync(id);
        if (fakas == null)
            throw new KeyNotFoundException("Kabinetas nerastas");
        return _mapper.Map<FakultetaiDTO>(fakas);
    }

    public async Task AddAsync(FakultetaiDTO fakas)
    {
        var entity = _mapper.Map<Fakultetai>(fakas);
        await _fakultetaiRepository.AddAsync(entity);
    }

    public async Task UpdateAsync(FakultetaiDTO fakas)
    {
        var entity = _mapper.Map<Fakultetai>(fakas);
        await _fakultetaiRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _fakultetaiRepository.DeleteAsync(id);
    }
}

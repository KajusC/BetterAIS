using AutoMapper;
using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Business.Services;

public class PazymiaiService : IPazymiaiService
{
    private readonly IPazymiaiRepository _pazymiaiRepository;
    private readonly IMapper _mapper;

    public PazymiaiService(IPazymiaiRepository pazymiaiRepository, IMapper mapper)
    {
        _pazymiaiRepository = pazymiaiRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PazymiaiDTO>> GetAllAsync()
    {
        var pazymiai = await _pazymiaiRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<PazymiaiDTO>>(pazymiai);
    }

    public async Task<PazymiaiDTO> GetByIdAsync(int id)
    {
        var pazymys = await _pazymiaiRepository.GetByIdAsync(id);
        if (pazymys == null)
            throw new KeyNotFoundException("Grade not found");
        return _mapper.Map<PazymiaiDTO>(pazymys);
    }

    public async Task AddAsync(PazymiaiDTO pazymys)
    {
        var entity = _mapper.Map<Pazymiai>(pazymys);
        await _pazymiaiRepository.AddAsync(entity);
    }

    public async Task UpdateAsync(PazymiaiDTO pazymys)
    {
        var entity = _mapper.Map<Pazymiai>(pazymys);
        await _pazymiaiRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _pazymiaiRepository.DeleteAsync(id);
    }
}

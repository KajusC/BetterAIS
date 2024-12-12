using AutoMapper;
using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Business.Services;

public class KabinetaiService : IKabinetaiService
{
    private readonly IKabinetaiRepository _kabinetaiRepository;
    private readonly IMapper _mapper;

    public KabinetaiService(IKabinetaiRepository kabinetaiRepository, IMapper mapper)
    {
        _kabinetaiRepository = kabinetaiRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<KabinetaiDTO>> GetAllAsync()
    {
        var moduliai = await _kabinetaiRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<KabinetaiDTO>>(moduliai);
    }

    public async Task<KabinetaiDTO> GetByIdAsync(int id)
    {
        var modulis = await _kabinetaiRepository.GetByIdAsync(id);
        if (modulis == null)
            throw new KeyNotFoundException("Kabinetas nerastas");
        return _mapper.Map<KabinetaiDTO>(modulis);
    }

    public async Task AddAsync(KabinetaiDTO modulis)
    {
        var entity = _mapper.Map<Kabinetai>(modulis);
        await _kabinetaiRepository.AddAsync(entity);
    }

    public async Task UpdateAsync(KabinetaiDTO kabinetas)
    {
        var entity = _mapper.Map<Kabinetai>(kabinetas);
        await _kabinetaiRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _kabinetaiRepository.DeleteAsync(id);
    }
}

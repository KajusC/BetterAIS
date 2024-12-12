using AutoMapper;
using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Business.Services;

public class ModulisService : IModuliaiService
{
    private readonly IModuliaiRepository _moduliaiRepository;
    private readonly IMapper _mapper;

    public ModulisService(IModuliaiRepository moduliaiRepository, IMapper mapper)
    {
        _moduliaiRepository = moduliaiRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ModuliaiDTO>> GetAllAsync()
    {
        var moduliai = await _moduliaiRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ModuliaiDTO>>(moduliai);
    }

    public async Task<ModuliaiDTO> GetByIdAsync(string id)
    {
        var modulis = await _moduliaiRepository.GetByIdAsync(id);
        if (modulis == null)
            throw new KeyNotFoundException("Modulis nerastas");
        return _mapper.Map<ModuliaiDTO>(modulis);
    }

    public async Task AddAsync(ModuliaiDTO modulis)
    {
        var entity = _mapper.Map<Moduliai>(modulis);
        await _moduliaiRepository.AddAsync(entity);
    }

    public async Task UpdateAsync(ModuliaiDTO pazymys)
    {
        var entity = _mapper.Map<Moduliai>(pazymys);
        await _moduliaiRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(string id)
    {
        await _moduliaiRepository.DeleteAsync(id);
    }
}

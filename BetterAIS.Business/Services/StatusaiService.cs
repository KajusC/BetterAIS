using AutoMapper;
using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Business.Services;

public class StatusaiService : IStatusaiService
{
    private readonly IStatusaiRepository _statusaiRepository;
    private readonly IMapper _mapper;

    public StatusaiService(IStatusaiRepository statusaiRepository, IMapper mapper)
    {
        _statusaiRepository = statusaiRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<StatusaiDTO>> GetAllAsync()
    {
        var entity = await _statusaiRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<StatusaiDTO>>(entity);
    }

    public async Task<StatusaiDTO> GetByIdAsync(int id)
    {
        var entity = await _statusaiRepository.GetByIdAsync(id);
        return _mapper.Map<StatusaiDTO>(entity);
    }

    public async Task AddAsync(StatusaiDTO model)
    {
        var entity = _mapper.Map<Statusai>(model);
        await _statusaiRepository.AddAsync(entity);
    }

    public async Task UpdateAsync(StatusaiDTO model)
    {
        var entity = _mapper.Map<Statusai>(model);
        await _statusaiRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int modelId)
    {
        await _statusaiRepository.DeleteAsync(modelId);
    }
}
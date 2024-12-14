using AutoMapper;
using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Business.Services;

public class UzsiemimoTipaiService : IUzsiemimoTipaiService
{
    private readonly IUzsiemimoTipaiRepository _uzsiemimoTipaiRepository;
    private readonly IMapper _mapper;

    public UzsiemimoTipaiService(IUzsiemimoTipaiRepository uzsiemimoTipaiRepository, IMapper mapper)
    {
        _uzsiemimoTipaiRepository = uzsiemimoTipaiRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UzsiemimoTipaiDTO>> GetAllAsync()
    {
        var entity = await _uzsiemimoTipaiRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UzsiemimoTipaiDTO>>(entity);
    }

    public async Task<UzsiemimoTipaiDTO> GetByIdAsync(int id)
    {
        var entity = await _uzsiemimoTipaiRepository.GetByIdAsync(id);
        return _mapper.Map<UzsiemimoTipaiDTO>(entity);
    }

    public async Task AddAsync(UzsiemimoTipaiDTO model)
    {
        var entity = _mapper.Map<UzsiemimoTipai>(model);
        await _uzsiemimoTipaiRepository.AddAsync(entity);
    }

    public async Task UpdateAsync(UzsiemimoTipaiDTO model)
    {
        var entity = _mapper.Map<UzsiemimoTipai>(model);
        await _uzsiemimoTipaiRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int modelId)
    {
        await _uzsiemimoTipaiRepository.DeleteAsync(modelId);
    }
}
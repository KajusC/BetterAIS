using AutoMapper;
using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Business.Services;

public class FinansavimoTipaiService : IFinansavimoTipaiService
{
    private readonly IFinansavimoTipaiRepository _repository;
    private readonly IMapper _mapper;

    public FinansavimoTipaiService(IFinansavimoTipaiRepository finTipai, IMapper mapper)
    {
        _repository = finTipai;
        _mapper = mapper;
    }
    public async Task<IEnumerable<FinansavimoTipaiDTO>> GetAllAsync()
    {
        var entity = await _repository.GetAllAsync();

        return _mapper.Map<IEnumerable<FinansavimoTipaiDTO>>(entity);
    }

    public async Task<FinansavimoTipaiDTO> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);

        return _mapper.Map<FinansavimoTipaiDTO>(entity);
    }

    public async Task AddAsync(FinansavimoTipaiDTO model)
    {
        var entity = _mapper.Map<FinansavimoTipai>(model);

        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(FinansavimoTipaiDTO model)
    {
        var entity = _mapper.Map<FinansavimoTipai>(model);

        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int modelId)
    {
        await _repository.DeleteAsync(modelId);
    }
}
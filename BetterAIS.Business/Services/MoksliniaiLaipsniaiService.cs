using AutoMapper;
using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Business.Services;

public class MoksliniaiLaipsniaiService : IMoksliniaiLaispniaiService
{
    private readonly IMoksliniaiLaipsniaiRepository _repository;
    private readonly IMapper _mapper;

    public MoksliniaiLaipsniaiService(IMoksliniaiLaipsniaiRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<MoksliniaiLaipsniaiDTO>> GetAllAsync()
    {
        var entity = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<MoksliniaiLaipsniaiDTO>>(entity);
    }

    public async Task<MoksliniaiLaipsniaiDTO> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<MoksliniaiLaipsniaiDTO>(entity);
    }

    public async Task AddAsync(MoksliniaiLaipsniaiDTO model)
    {
        var entity = _mapper.Map<MoksliniaiLaipsniai>(model);
        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(MoksliniaiLaipsniaiDTO model)
    {
        var entity = _mapper.Map<MoksliniaiLaipsniai>(model);
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int modelId)
    {
        await _repository.DeleteAsync(modelId);
    }
}
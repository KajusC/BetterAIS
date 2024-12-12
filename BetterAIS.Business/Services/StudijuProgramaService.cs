using AutoMapper;
using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Business.Services;

public class StudijuProgramaService : IStudijuProgramaService
{
    private readonly IStudijuProgramaRepository _studijuProgramaRepository;
    private readonly IMoksliniaiLaipsniaiRepository _moksliniaiLaipsniaiRepository;

    private readonly IMapper _mapper;

    public StudijuProgramaService(
        IStudijuProgramaRepository studijuProgramaRepository,
        IMoksliniaiLaipsniaiRepository moksliniaiLaipsniaiRepository,
        IMapper mapper)
    {
        _studijuProgramaRepository = studijuProgramaRepository;
        _moksliniaiLaipsniaiRepository = moksliniaiLaipsniaiRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<StudijuProgramaDTO>> GetAllAsync()
    {
        var entities = await _studijuProgramaRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<StudijuProgramaDTO>>(entities);
    }

    public async Task<StudijuProgramaDTO> GetByIdAsync(string id)
    {
        var entity = await _studijuProgramaRepository.GetByIdAsync(id);
        return _mapper.Map<StudijuProgramaDTO>(entity);
    }

    public async Task AddAsync(StudijuProgramaDTO model)
    {
        var entity = _mapper.Map<StudijuPrograma>(model);

        var mokslinisLaipsnis = await _moksliniaiLaipsniaiRepository.GetByIdAsync(model.MokslinisLaipsnis);
        entity.MokslinisLaipsnisNavigation = mokslinisLaipsnis;

        await _studijuProgramaRepository.AddAsync(entity);
    }

    public async Task UpdateAsync(StudijuProgramaDTO model)
    {
        var entity = _mapper.Map<StudijuPrograma>(model);
        await _studijuProgramaRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(string modelId)
    {
        await _studijuProgramaRepository.DeleteAsync(modelId);
    }
}
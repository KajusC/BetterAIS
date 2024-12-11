using AutoMapper;
using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Business.Services;

public class UzduotysService : IUzduotysService
{
    private readonly IUzduotysRepository _repository;
    private readonly IMapper _mapper;

    public UzduotysService(IUzduotysRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UzduotysDTO>> GetAllAsync()
    {
        var uzduotys = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<UzduotysDTO>>(uzduotys);
    }

    public async Task<UzduotysDTO> GetByIdAsync(int id)
    {
        var uzduotis = await _repository.GetByIdAsync(id);
        return _mapper.Map<UzduotysDTO>(uzduotis);
    }

    public async Task AddAsync(UzduotysDTO uzduotisDto)
    {
        var uzduotis = _mapper.Map<Uzduotys>(uzduotisDto);
        await _repository.AddAsync(uzduotis);
    }

    public async Task UpdateAsync(UzduotysDTO uzduotisDto)
    {
        var uzduotis = _mapper.Map<Uzduotys>(uzduotisDto);
        await _repository.UpdateAsync(uzduotis);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}

using AutoMapper;
using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;
using BCrypt.Net;

namespace BetterAIS.Business.Services;

public class VartotojaiService : IVartotojaiService
{
    private readonly IVartotojaiRepository _vartotojaiRepository;
    private readonly IStudentaiRepository _studentaiRepository;
    private readonly IDestytojaiRepository _destytojaiRepository;

    private readonly IMapper _mapper;

    public VartotojaiService(IVartotojaiRepository vartotojaiRepository,
        IStudentaiRepository studentaiRepository,
        IDestytojaiRepository destytojaiRepository,
        IMapper mapper)
    {
        _vartotojaiRepository = vartotojaiRepository;
        _studentaiRepository = studentaiRepository;
        _destytojaiRepository = destytojaiRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<VartotojaiDTO>> GetAllAsync()
    {
        var entities = await _vartotojaiRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<VartotojaiDTO>>(entities);
    }

    public async Task<VartotojaiDTO> GetByIdAsync(string vidko)
    {
        var entity = await _vartotojaiRepository.GetByIdAsync(vidko);
        return _mapper.Map<VartotojaiDTO>(entity);
    }

    public async Task AddAsync(VartotojaiDTO model)
    {
        var entity = _mapper.Map<Vartotojai>(model);

        entity.Vidko = entity.Vidko.ToUpper();
        entity.Slaptazodis = BCrypt.Net.BCrypt.HashPassword(entity.Slaptazodis);

        await _vartotojaiRepository.AddAsync(entity);
    }

    public async Task UpdateAsync(VartotojaiDTO model)
    {
        var entity = _mapper.Map<Vartotojai>(model);
        await _vartotojaiRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(string modelId)
    {
        await _vartotojaiRepository.DeleteAsync(modelId);
    }

    public async Task AddStudentVartotojas(VartotojaiDTO vartotojaiModel, StudentaiDTO studentaiModel)
    {
        // Map DTOs to entities
        var vartotojaiEntity = _mapper.Map<Vartotojai>(vartotojaiModel);
        var studentaiEntity = _mapper.Map<Studentai>(studentaiModel);

        vartotojaiEntity.Vidko = vartotojaiEntity.Vidko.ToUpper();

        vartotojaiEntity.Slaptazodis = BCrypt.Net.BCrypt.HashPassword(vartotojaiEntity.Slaptazodis);

        vartotojaiEntity.Studentai = studentaiEntity;

        await _vartotojaiRepository.AddAsync(vartotojaiEntity);
    }

    public async Task AddDestytojaiVartotojas(VartotojaiDTO vartotojaiModel, DestytojaiDTO destytojaiModel)
    {
        var vartotojaiEntity = _mapper.Map<Vartotojai>(vartotojaiModel);
        var destytojaiEntity = _mapper.Map<Destytojai>(destytojaiModel);

        vartotojaiEntity.Vidko = vartotojaiEntity.Vidko.ToUpper();
        vartotojaiEntity.Slaptazodis = BCrypt.Net.BCrypt.HashPassword(vartotojaiEntity.Slaptazodis);
        vartotojaiEntity.Destytojai = destytojaiEntity;

        await _vartotojaiRepository.AddAsync(vartotojaiEntity);
    }

    public async Task UpdateStudentas(StudentaiDTO studentaiModel, VartotojaiDTO vartotojaiModel)
    {
        var studentaiEntity = _mapper.Map<Studentai>(studentaiModel);
        var vartotojaiEntity = _mapper.Map<Vartotojai>(vartotojaiModel);

        studentaiEntity.Vidko = studentaiEntity.Vidko.ToUpper();
        vartotojaiEntity.Vidko = vartotojaiEntity.Vidko.ToUpper();

        studentaiEntity.VidkoNavigation = vartotojaiEntity;

        await _studentaiRepository.UpdateAsync(studentaiEntity);
        await _vartotojaiRepository.UpdateAsync(vartotojaiEntity);
    }

    public async Task UpdateDestytojas(DestytojaiDTO destytojaiModel, VartotojaiDTO vartotojaiModel)
    {
        var destytojaiEntity = _mapper.Map<Destytojai>(destytojaiModel);
        var vartotojaiEntity = _mapper.Map<Vartotojai>(vartotojaiModel);

        destytojaiEntity.Vidko = destytojaiEntity.Vidko.ToUpper();
        vartotojaiEntity.Vidko = vartotojaiEntity.Vidko.ToUpper();

        destytojaiEntity.VidkoNavigation = vartotojaiEntity;

        await _destytojaiRepository.UpdateAsync(destytojaiEntity);
        await _vartotojaiRepository.UpdateAsync(vartotojaiEntity);
    }

    public async Task DeleteStudentas(string modelId)
    {
        await _studentaiRepository.DeleteAsync(modelId);

        var vartotojas = await _vartotojaiRepository.GetByIdAsync(modelId);
        await _vartotojaiRepository.DeleteAsync(vartotojas.Vidko);
    }

    public async Task DeleteDestytojas(string modelId)
    {
        await _destytojaiRepository.DeleteAsync(modelId);

        var vartotojas = await _vartotojaiRepository.GetByIdAsync(modelId);
        await _vartotojaiRepository.DeleteAsync(vartotojas.Vidko);
    }
}
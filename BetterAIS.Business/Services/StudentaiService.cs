﻿using AutoMapper;
using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Business.Services;

public class StudentaiService : IStudentaiService
{
    private readonly IStudentaiRepository _repository;
    private readonly IMapper _mapper;

    private readonly IVartotojaiService _vartotojaiService;

    public StudentaiService(IStudentaiRepository repository, IVartotojaiService vartotojaiService, IMapper mapper)
    {
        _repository = repository;
        _vartotojaiService = vartotojaiService;
        _mapper = mapper;
    }
    public async Task<IEnumerable<StudentaiDTO>> GetAllAsync()
    {
        var entity = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<StudentaiDTO>>(entity);
    }

    public async Task<StudentaiDTO> GetByIdAsync(string id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<StudentaiDTO>(entity);
    }

    public async Task AddAsync(StudentaiDTO studentaiModel)
    {
        // ALL adding logic is moved to VartotojaiService
        var vartotojaiModel = new VartotojaiDTO
        {
            Vidko = studentaiModel.Vidko,
            Slaptazodis = studentaiModel.Slaptazodis,
            Vardas = studentaiModel.Vardas,
            GimimoData = studentaiModel.GimimoData,
            Pavarde = studentaiModel.Pavarde,
            ElPastas = studentaiModel.ElPastas,
            TelefonoNr = studentaiModel.TelefonoNr,
            RoleId = studentaiModel.RoleId
        };

        await _vartotojaiService.AddStudentVartotojas(vartotojaiModel, studentaiModel);
    }

    public async Task UpdateAsync(StudentaiDTO studentaiModel)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(string modelId)
    {
        throw new NotImplementedException();
    }

}
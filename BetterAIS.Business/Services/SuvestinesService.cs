using AutoMapper;
using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;
using BetterAIS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterAIS.Business.Services
{
    public class SuvestinesService : ISuvestinesService
    {
        private readonly ISuvestineRepository _repository;
        private readonly IMapper _mapper;

        public SuvestinesService(ISuvestineRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task AddAsync(SuvestinesDTO suvestinesModel)
        {
            var entity = _mapper.Map<Suvestine>(suvestinesModel);
            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SuvestinesDTO>> GetAllAsync()
        {
            var entity = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<SuvestinesDTO>>(entity);
        }

        public async Task<SuvestinesDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<SuvestinesDTO>(entity);
        }

        public async Task UpdateAsync(SuvestinesDTO suvestinesModel)
        {
            var entity = _mapper.Map<Suvestine>(suvestinesModel);
            await _repository.UpdateAsync(entity);
        }

        public async Task<IEnumerable<Suvestine>> GetSuvestinesByVidko(string vidko)
        {
            var entity = await _repository.GetAllAsync();
            var studentTasks = entity.Where(x => x.FkStudentasVidko == vidko);

            return studentTasks;
        }

    }
}

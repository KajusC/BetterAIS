using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using AutoMapper;
using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Business.Services
{
    public class DestytojaiService : IDestytojaiService
    {
        private readonly IDestytojaiRepository _repository;
        private readonly IVartotojaiRepository _repositoryUsers;
        private readonly IMapper _mapper;
        private readonly IVartotojaiService _vartotojaiService;

        public DestytojaiService(IDestytojaiRepository repository, IVartotojaiService vartotojaiService, IMapper mapper)
        {
            _repository = repository;
            _vartotojaiService = vartotojaiService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DestytojaiDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DestytojaiDTO>>(entities);
        }

        public async Task<DestytojaiDTO> GetByIdAsync(string vidko)
        {
            var entity = await _repository.GetByIdAsync(vidko);
            return _mapper.Map<DestytojaiDTO>(entity);
        }

        public async Task AddAsync(DestytojaiDTO destytojaiModel)
        {
            var vartotojaiModel = new VartotojaiDTO
            {
                Vidko = destytojaiModel.Vidko,
                Slaptazodis = destytojaiModel.Slaptazodis,
                Vardas = destytojaiModel.Vardas,
                GimimoData = destytojaiModel.GimimoData,
                Pavarde = destytojaiModel.Pavarde,
                ElPastas = destytojaiModel.ElPastas,
                TelefonoNr = destytojaiModel.TelefonoNr,
                RoleId = destytojaiModel.RoleId
            };

            await _vartotojaiService.AddDestytojaiVartotojas(vartotojaiModel, destytojaiModel);
        }

        public async Task UpdateAsync(DestytojaiDTO destytojaiModel)
        {

            var entity = _mapper.Map<Destytojai>(destytojaiModel);

            if (entity == null)
            {
                throw new KeyNotFoundException();
            }
            var vartotojaiModel = new VartotojaiDTO
            {
                Vidko = destytojaiModel.Vidko,
                Slaptazodis = destytojaiModel.Slaptazodis,
                Vardas = destytojaiModel.Vardas,
                GimimoData = destytojaiModel.GimimoData,
                Pavarde = destytojaiModel.Pavarde,
                ElPastas = destytojaiModel.ElPastas,
                TelefonoNr = destytojaiModel.TelefonoNr,
                RoleId = destytojaiModel.RoleId
            };

            await _vartotojaiService.UpdateAsync(vartotojaiModel);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(string vidko)
        {
            await _repository.DeleteAsync(vidko);
            await _vartotojaiService.DeleteAsync(vidko);
        }
    }
}

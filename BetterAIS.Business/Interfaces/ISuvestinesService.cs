using BetterAIS.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterAIS.Business.Interfaces
{
    public interface ISuvestinesService
    {
        Task<IEnumerable<SuvestinesDTO>> GetAllAsync();

        Task<SuvestinesDTO> GetByIdAsync(int id);

        Task AddAsync(SuvestinesDTO suvestinesModel);

        Task UpdateAsync(SuvestinesDTO suvestinesModel);

        Task DeleteAsync(int id);
    }
}

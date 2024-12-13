using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterAIS.Data.Models;

namespace BetterAIS.Data.Interfaces
{
    public interface IDestytojaiRepository : IRepository<Destytojai, string>
    {
        Task<string> GetLatestVidkoAsync();
        Task<List<Paskaitos>> GetTeacherTimetable(string vidko);
    }
}

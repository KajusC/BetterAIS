using BetterAIS.Data.Models;
using System.Reflection;

namespace BetterAIS.Data.Interfaces;

public interface IModuliaiRepository : IRepository<Moduliai, string>
{
    Task<List<Moduliai>> GetModulesByTeacherIdAsync(string vidko);
}
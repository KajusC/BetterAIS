﻿using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Data.Repositories;

public class ModuliaiRepository : IModuliaiRepository
{
    public async Task<IEnumerable<Moduliai>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Moduliai> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Moduliai entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Moduliai entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}
﻿using BetterAIS.Data.Interfaces;
using BetterAIS.Data.Models;

namespace BetterAIS.Data.Repositories;

public class VartotojaiRepository : IVartotojaiRepository
{
    public async Task<IEnumerable<Vartotojai>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Vartotojai> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Vartotojai entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Vartotojai entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}
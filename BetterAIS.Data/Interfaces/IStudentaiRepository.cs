﻿using BetterAIS.Data.Models;

namespace BetterAIS.Data.Interfaces;

public interface IStudentaiRepository : IRepository<Studentai, string>
{
    Task<string> GetLatestVidkoAsync();
}
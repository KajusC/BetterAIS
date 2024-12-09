using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterAIS.Business.DTO;
using BetterAIS.Business.Models;

namespace BetterAIS.Business.Interfaces
{
    public interface IAuthenticatorService
    {
        Task<string> Login(LoginModel loginModel);
        Task Logout(string token);
        Task<bool> Verify(string token);
    }
}

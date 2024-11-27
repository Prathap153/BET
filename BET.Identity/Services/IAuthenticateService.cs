using BET.Identity.Models.Login;
using BET.Identity.Models.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Identity.Services
{
    public interface IAuthenticateService
    {
        Task<string> RegisterUser(RegisterUser registerUser, string role);
        Task<string> Login(LoginModel loginModel);
    }
}

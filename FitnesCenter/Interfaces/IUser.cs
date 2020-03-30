using FitnesCenter.VIewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnesCenter.Interfaces
{
    public interface IUser
    {
        Task<ResultViewModel> RegistrationAsync(ReistrationViewModel model);
        Task<ResultViewModel> LoginAsync(LoginViewModel model);
        Task<ResultViewModel> ChangePasswordAsync(string email, ChangePasswordViewModel model);
    }
}

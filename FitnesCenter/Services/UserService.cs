using FitnesCenter.VIewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FitnesCenter.Models;
using Microsoft.EntityFrameworkCore;
using FitnesCenter.BusinessModels;
using FitnesCenter.Interfaces;
using FitnesCenter.Extensions;

namespace FitnesCenter.Services
{
    public class UserService: IUser, IClient
    {
        TrComDBContext DBContext;

        public UserService()
        {
            DBContext = new TrComDBContext();
        }

        public async Task<ResultViewModel> RegistrationAsync(ReistrationViewModel registrationViewModel)
        {
            try
            {
                if (registrationViewModel == null)
                {
                    return new ResultViewModel((int)HttpStatusCode.BadRequest, "Null Request.");
                }

                User currentUser = await DBContext.User.FirstOrDefaultAsync(e => e.Email == registrationViewModel.Email);

                if (currentUser != null)
                {
                    return new ResultViewModel((int)HttpStatusCode.BadRequest, "User already exist");
                }

                PasswordHasher hasher = new PasswordHasher(registrationViewModel.Password);

                User user = new User
                {
                    Email = registrationViewModel.Email,
                    Password = hasher.GetHash(),
                    LastName = registrationViewModel.LastName,
                    FirstName = registrationViewModel.FirstName,
                    ThirdName = registrationViewModel.ThirdName,
                    RegistrationDate = DateTime.Now.Date,
                    MobilePhone = registrationViewModel.Phone,
                    RoleId = 2,
                };

                await Task.Run(() => DBContext.User.AddAsync(user));
                await Task.Run(() => DBContext.SaveChangesAsync());
                Task.WaitAll();
                await Task.Run(() => AddClientAsync(user.Id));

                AdditionalLoginInformation additionalLoginInformation = new AdditionalLoginInformation(new JwtCreater(user.Email, DBContext.Role.FirstOrDefaultAsync(e => e.Id == user.RoleId).Result.Name).GetJwt());

                return new ResultViewModel((int)HttpStatusCode.OK, "", null, additionalLoginInformation);
            }
            catch(Exception ex)
            {
                return new ResultViewModel((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<ResultViewModel> LoginAsync(LoginViewModel loginViewModel)
        {
            try
            {
                if (loginViewModel == null)
                {
                    return new ResultViewModel((int)HttpStatusCode.BadRequest, "Invalid request.");
                }

                var currentUser = await DBContext.User.FirstOrDefaultAsync(e => e.Email == loginViewModel.Email && e.Password == new PasswordHasher(loginViewModel.Password).GetHash());
                Task.WaitAll();

                if (currentUser == null)
                {
                    return new ResultViewModel((int)HttpStatusCode.BadRequest, "Incorrect login or password.");
                }

                currentUser.Role = await DBContext.Role.FirstAsync(t => t.Id == currentUser.RoleId);
                Task.WaitAll();

                AdditionalLoginInformation additionalLoginInformation = new AdditionalLoginInformation(
                        new JwtCreater(currentUser.Email,
                        DBContext.Role.FirstOrDefaultAsync(e => e.Id == currentUser.RoleId).Result.Name).GetJwt(), "Login is OK", currentUser.IsFirstEntry, currentUser.Role.Name);
                return new ResultViewModel((int)HttpStatusCode.OK, "", null, additionalLoginInformation);
            }
            catch(Exception ex)
            {
                return new ResultViewModel((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private async Task AddClientAsync(int userId)
        {
            Client client = new Client
            {
                UserId = userId
            };
            await Task.Run(() => DBContext.Client.AddAsync(client));
            Task.WaitAll();
            await Task.Run(() => DBContext.SaveChangesAsync());
        }

        public async Task<ResultViewModel> ChangePasswordAsync(string email, ChangePasswordViewModel changePasswordViewModel)
        {
            try 
            {
                if (changePasswordViewModel == null)
                {
                    return new ResultViewModel((int)HttpStatusCode.BadRequest, "Invalid request.");
                }

                var currentUser = await DBContext.User.FirstOrDefaultAsync(e => e.Email == email && e.Password == new PasswordHasher(changePasswordViewModel.OldPassword).GetHash());

                if (currentUser == null)
                {
                    return new ResultViewModel((int)HttpStatusCode.BadRequest, "Incorrect login or old password.");
                }

                PasswordHasher hasher = new PasswordHasher(changePasswordViewModel.NewPassword);

                currentUser.Password = hasher.GetHash();

                await Task.Run(() => DBContext.User.Update(currentUser));

                return new ResultViewModel((int)HttpStatusCode.OK, "Password changed.");
            }
            catch(Exception ex)
            {
                return new ResultViewModel((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}

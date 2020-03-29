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
                Task.WaitAll();
                await Task.Run(() => AddClientAsync(user.Id));

                return new ResultViewModel((int)HttpStatusCode.OK, new JwtCreater(user.Email, DBContext.Role.FirstOrDefaultAsync(e => e.Id == user.RoleId).Result.Name).GetJwt());
            }
            catch(Exception ex)
            {
                return new ResultViewModel((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<ResultViewModel> LoginAsync(LoginViewModel loginViewModel)
        {
            if (loginViewModel == null)
            {
                return new ResultViewModel((int)HttpStatusCode.BadRequest, "Invalid request.");
            }

            var currentUser = await DBContext.User.FirstOrDefaultAsync(e => e.Email == loginViewModel.Email && e.Password == new PasswordHasher(loginViewModel.Password).GetHash());

            if (currentUser == null)
            {
                return new ResultViewModel((int)HttpStatusCode.BadRequest, "Incorrect login or password.");
            }

            return new ResultViewModel((int)HttpStatusCode.OK, new JwtCreater(currentUser.Email,
                    DBContext.Role.FirstOrDefaultAsync(e => e.Id == currentUser.RoleId).Result.Name).GetJwt());
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
    }
}

using FitnesCenter.BusinessModels;
using FitnesCenter.Extensions;
using FitnesCenter.Models;
using FitnesCenter.VIewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FitnesCenter.Services
{
    public class AdminService
    {
        TrComDBContext DBContext;

        public AdminService()
        {
            DBContext = new TrComDBContext();
        }

        public async Task<ResultViewModel> AddTrainerAsync(AddTrainerViewModel addTrainerViewModel)
        {
            try
            {
                if (addTrainerViewModel == null)
                {
                    return new ResultViewModel((int)HttpStatusCode.BadRequest, "Null Request.");
                }

                bool? result = await TrainerExtender.IsTrainerExist(addTrainerViewModel.Email);

                if (result == null)
                {
                    return new ResultViewModel((int)HttpStatusCode.BadRequest, "Null Request.");
                }

                if (result == true)
                {
                    return new ResultViewModel((int)HttpStatusCode.BadRequest, "Trainer has already exist.");
                }

                string password = PasswordGenerator.Get8CharactersPassword();

                PasswordHasher hasher = new PasswordHasher(password);

                User user = new User
                {
                    Email = addTrainerViewModel.Email,
                    Password = hasher.GetHash(),
                    LastName = addTrainerViewModel.LastName,
                    FirstName = addTrainerViewModel.FirstName,
                    ThirdName = addTrainerViewModel.ThirdName,
                    RegistrationDate = DateTime.Now.Date,
                    MobilePhone = addTrainerViewModel.Phone,
                    RoleId = 3
                };

                await DBContext.User.AddAsync(user);
                Task.WaitAll();

                Trainer trainer = new Trainer()
                {
                    UserId = user.Id
                };

                await DBContext.Trainer.AddAsync(trainer);
                Task.WaitAll();

                return new ResultViewModel((int)HttpStatusCode.OK, "Trainer is added successfully.");
            }
            catch (Exception ex)
            {
                return new ResultViewModel((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

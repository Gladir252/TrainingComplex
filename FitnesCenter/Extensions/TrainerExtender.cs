using FitnesCenter.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnesCenter.Extensions
{
    public static class TrainerExtender
    {
        private static readonly TrComDBContext context = new TrComDBContext();

        public static async Task<Trainer> GetFullTrainerInfoAsync(User user)
        {
            if(user == null || user.Id == 0)
            {
                return null;
            }

            Trainer trainer = await context.Trainer.FirstOrDefaultAsync(t => t.UserId == user.Id);
            Task.WaitAll();

            if(trainer == null)
            {
                return null;
            }

            trainer.User = await context.User.FirstOrDefaultAsync(t => t.Id == trainer.UserId);
            trainer.Training = await context.Training.Where(t => t.TrainerId == trainer.Id).ToListAsync();
            trainer.DayOff = await context.DayOff.Where(t => t.TrainerId == trainer.Id).ToListAsync();
            Task.WaitAll();
            
            for (int i = 0; i < trainer.DayOff.Count; i++)
            {
                trainer.DayOff.ToList()[i].TimeOff = await context.TimeOff.Where(t => t.DayOffId == trainer.DayOff.ToList()[i].Id).ToListAsync();
            }

            Task.WaitAll();

            return trainer;
        }

        public static async Task<Trainer> GetFullTrainerInfoAsync(Trainer trainer)
        {
            if (trainer == null || trainer.Id == 0)
            {
                return null;
            }

            trainer.User = await context.User.FirstOrDefaultAsync(t => t.Id == trainer.UserId);
            trainer.Training = await context.Training.Where(t => t.TrainerId == trainer.Id).ToListAsync();
            trainer.DayOff = await context.DayOff.Where(t => t.TrainerId == trainer.Id).ToListAsync();
            Task.WaitAll();
            
            for (int i = 0; i < trainer.DayOff.Count; i++)
            {
                trainer.DayOff.ToList()[i].TimeOff = await context.TimeOff.Where(t => t.DayOffId == trainer.DayOff.ToList()[i].Id).ToListAsync();
            }

            Task.WaitAll();

            return trainer;
        }

        public static async Task<bool?> IsTrainerExist(string email)
        {
            if(email == null)
            {
                return null;
            }

            User user = await context.User.FirstOrDefaultAsync(t=>t.Email == email);
            Task.WaitAll();
            
            if(user == null)
            {
                return false;
            }

            Trainer trainer = await context.Trainer.FirstOrDefaultAsync(t => t.UserId == user.Id);
            Task.WaitAll();

            if(trainer == null)
            {
                return false;
            }

            return true;
        }
    }
}
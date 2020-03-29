using System;
using System.Collections.Generic;

namespace FitnesCenter.Models
{
    public partial class Training
    {
        public Training()
        {
            ClientTraining = new HashSet<ClientTraining>();
            Respite = new HashSet<Respite>();
            TrainingCategory = new HashSet<TrainingCategory>();
            Workout = new HashSet<Workout>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime Date { get; set; }
        public int TrainerId { get; set; }

        public virtual Trainer Trainer { get; set; }
        public virtual ICollection<ClientTraining> ClientTraining { get; set; }
        public virtual ICollection<Respite> Respite { get; set; }
        public virtual ICollection<TrainingCategory> TrainingCategory { get; set; }
        public virtual ICollection<Workout> Workout { get; set; }
    }
}

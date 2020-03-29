using System;
using System.Collections.Generic;

namespace FitnesCenter.Models
{
    public partial class Workout
    {
        public Workout()
        {
            ExerciseWorkout = new HashSet<ExerciseWorkout>();
        }

        public int Id { get; set; }
        public int TrainingId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int? CountOfTimes { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Distance { get; set; }
        public decimal? Duration { get; set; }

        public virtual Training Training { get; set; }
        public virtual ICollection<ExerciseWorkout> ExerciseWorkout { get; set; }
    }
}

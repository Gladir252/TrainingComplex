using System;
using System.Collections.Generic;

namespace FitnesCenter.Models
{
    public partial class ExerciseWorkout
    {
        public int ExerciseId { get; set; }
        public int WorkoutId { get; set; }

        public virtual Exercise Exercise { get; set; }
        public virtual Workout Workout { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FitnesCenter.Models
{
    public partial class Exercise
    {
        public Exercise()
        {
            ExerciseCategory = new HashSet<ExerciseCategory>();
            ExerciseMuscleGroup = new HashSet<ExerciseMuscleGroup>();
            ExerciseWorkout = new HashSet<ExerciseWorkout>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<ExerciseCategory> ExerciseCategory { get; set; }
        public virtual ICollection<ExerciseMuscleGroup> ExerciseMuscleGroup { get; set; }
        public virtual ICollection<ExerciseWorkout> ExerciseWorkout { get; set; }
    }
}

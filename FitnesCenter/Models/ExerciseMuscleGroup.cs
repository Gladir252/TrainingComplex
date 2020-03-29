using System;
using System.Collections.Generic;

namespace FitnesCenter.Models
{
    public partial class ExerciseMuscleGroup
    {
        public int ExerciseId { get; set; }
        public int MuscleGroupId { get; set; }

        public virtual Exercise Exercise { get; set; }
        public virtual MuscleGroup MuscleGroup { get; set; }
    }
}

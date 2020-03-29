using System;
using System.Collections.Generic;

namespace FitnesCenter.Models
{
    public partial class MuscleGroup
    {
        public MuscleGroup()
        {
            ExerciseMuscleGroup = new HashSet<ExerciseMuscleGroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<ExerciseMuscleGroup> ExerciseMuscleGroup { get; set; }
    }
}

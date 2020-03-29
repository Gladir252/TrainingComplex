using System;
using System.Collections.Generic;

namespace FitnesCenter.Models
{
    public partial class Category
    {
        public Category()
        {
            ExerciseCategory = new HashSet<ExerciseCategory>();
            TrainingCategory = new HashSet<TrainingCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public virtual ICollection<ExerciseCategory> ExerciseCategory { get; set; }
        public virtual ICollection<TrainingCategory> TrainingCategory { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FitnesCenter.Models
{
    public partial class ExerciseCategory
    {
        public int ExerciseId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}

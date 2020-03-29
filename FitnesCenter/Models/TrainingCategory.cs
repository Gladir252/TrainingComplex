using System;
using System.Collections.Generic;

namespace FitnesCenter.Models
{
    public partial class TrainingCategory
    {
        public int TrainingId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Training Training { get; set; }
    }
}

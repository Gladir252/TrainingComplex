using System;
using System.Collections.Generic;

namespace FitnesCenter.Models
{
    public partial class Respite
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public virtual Training Training { get; set; }
    }
}

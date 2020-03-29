using System;
using System.Collections.Generic;

namespace FitnesCenter.Models
{
    public partial class DayOff
    {
        public DayOff()
        {
            TimeOff = new HashSet<TimeOff>();
        }

        public int Id { get; set; }
        public int TrainerId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool IsFullDate { get; set; }

        public virtual Trainer Trainer { get; set; }
        public virtual ICollection<TimeOff> TimeOff { get; set; }
    }
}

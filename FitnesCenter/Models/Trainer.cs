using System;
using System.Collections.Generic;

namespace FitnesCenter.Models
{
    public partial class Trainer
    {
        public Trainer()
        {
            DayOff = new HashSet<DayOff>();
            Training = new HashSet<Training>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Specialization { get; set; }
        public string Experience { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<DayOff> DayOff { get; set; }
        public virtual ICollection<Training> Training { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FitnesCenter.Models
{
    public partial class TimeOff
    {
        public int Id { get; set; }
        public int DayOffId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public virtual DayOff DayOff { get; set; }
    }
}

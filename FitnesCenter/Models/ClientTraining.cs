using System;
using System.Collections.Generic;

namespace FitnesCenter.Models
{
    public partial class ClientTraining
    {
        public int TrainingId { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Training Training { get; set; }
    }
}

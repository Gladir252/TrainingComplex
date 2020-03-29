using System;
using System.Collections.Generic;

namespace FitnesCenter.Models
{
    public partial class Client
    {
        public Client()
        {
            ClientTraining = new HashSet<ClientTraining>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Preferences { get; set; }
        public int? RationId { get; set; }

        public virtual Ration Ration { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ClientTraining> ClientTraining { get; set; }
    }
}

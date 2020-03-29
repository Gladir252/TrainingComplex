using System;
using System.Collections.Generic;

namespace FitnesCenter.Models
{
    public partial class Ration
    {
        public Ration()
        {
            Client = new HashSet<Client>();
            Ingestion = new HashSet<Ingestion>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Client> Client { get; set; }
        public virtual ICollection<Ingestion> Ingestion { get; set; }
    }
}

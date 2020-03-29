using System;
using System.Collections.Generic;

namespace FitnesCenter.Models
{
    public partial class AbonementType
    {
        public AbonementType()
        {
            Abonement = new HashSet<Abonement>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Abonement> Abonement { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FitnesCenter.Models
{
    public partial class Ingestion
    {
        public Ingestion()
        {
            FoodProduct = new HashSet<FoodProduct>();
        }

        public int Id { get; set; }
        public TimeSpan Time { get; set; }
        public string Description { get; set; }
        public int RationId { get; set; }

        public virtual Ration Ration { get; set; }
        public virtual ICollection<FoodProduct> FoodProduct { get; set; }
    }
}

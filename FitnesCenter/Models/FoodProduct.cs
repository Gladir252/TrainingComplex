using System;
using System.Collections.Generic;

namespace FitnesCenter.Models
{
    public partial class FoodProduct
    {
        public int Id { get; set; }
        public decimal Weight { get; set; }
        public decimal? Kilocalories { get; set; }
        public int IngestionId { get; set; }

        public virtual Ingestion Ingestion { get; set; }
    }
}

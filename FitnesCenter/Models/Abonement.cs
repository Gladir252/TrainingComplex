using System;
using System.Collections.Generic;

namespace FitnesCenter.Models
{
    public partial class Abonement
    {
        public int Id { get; set; }
        public int AbonementTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PaymentStatus { get; set; }
        public bool IsActive { get; set; }

        public virtual AbonementType AbonementType { get; set; }
    }
}

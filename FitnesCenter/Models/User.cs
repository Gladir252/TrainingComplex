using System;
using System.Collections.Generic;

namespace FitnesCenter.Models
{
    public partial class User
    {
        public User()
        {
            Client = new HashSet<Client>();
            Trainer = new HashSet<Trainer>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string ThirdName { get; set; }
        public byte[] Photo { get; set; }
        public string MobilePhone { get; set; }
        public DateTime? Birthday { get; set; }
        public string AboutMe { get; set; }
        public int RoleId { get; set; }
        public bool? IsFirstEntry { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Client> Client { get; set; }
        public virtual ICollection<Trainer> Trainer { get; set; }
    }
}

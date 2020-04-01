using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnesCenter.VIewModels
{
    public class AddTrainerViewModel
    {
        [Required(ErrorMessage = "First name cannot be empty.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name cannot be empty.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Last name cannot be empty.")]
        public string ThirdName { get; set; }

        [Required(ErrorMessage = "Phone cannot be empty.")]
        [Phone(ErrorMessage = "Incorrect phone.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email cannot be empty.")]
        [EmailAddress(ErrorMessage = "Incorrect email address.")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect entry format")]
        public string Email { get; set; }
        //TODO: валидацию сюда
        public string Specialization { get; set; }
        //и сюда
        public string Experience { get; set; }
    }
}

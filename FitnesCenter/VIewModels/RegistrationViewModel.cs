using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnesCenter.VIewModels
{
    public class ReistrationViewModel
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
        //TO DO: регулярку исправь
        //[RegularExpression("/(?=.*[0-9])(?=.*[a-zA-z])[0-9a-zA-Z]{6,}/g",
        //    ErrorMessage = "Incorrect entry format. Password should contain 6+ symbols, and contain at least one letter")]
        [Required(ErrorMessage = "Password cannot be empty.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password dublicate cannot be empty.")]
        [Compare("Password", ErrorMessage = "Passwords not confirmed")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}

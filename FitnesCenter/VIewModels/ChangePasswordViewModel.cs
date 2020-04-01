using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnesCenter.VIewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Old password cannot be empty.")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "New password cannot be empty.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Password dublicate cannot be empty.")]
        [Compare("NewPassword", ErrorMessage = "Passwords not confirmed")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Table.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Enter your name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Repeat your password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords are not same")]
        [Display(Name = "Password confirm")]
        public string PasswordConfirm { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Table.Domain.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            this.RegistrationDate = DateTime.Now;
            this.LastActivity = DateTime.Now;
            this.Status = "online";
        }

        [Required]
        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [Display(Name = "Last Activity")]
        public DateTime LastActivity { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }
    }
}

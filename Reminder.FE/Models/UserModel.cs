using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reminder.FE.Models
{
    public partial class UserModel
    {
        public int Id { get; set; }
        [Display(Name = "User Name"), Required(ErrorMessage = "required")]
        public string? UserName { get; set; }

        [Display(Name = "Email"), Required(ErrorMessage = "required")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage = "InvalidEmail")]
        public string? Email { get; set; }
        public string? Password { get; set; }
        [Display(Name = "Deleted")]

        public bool Deleted { get; set; }
      
    }
}

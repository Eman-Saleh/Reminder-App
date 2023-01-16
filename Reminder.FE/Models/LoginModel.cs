using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reminder.FE.Models
{
    public partial class LoginModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "required")]
        public string? Password { get; set; }
        
    }
}

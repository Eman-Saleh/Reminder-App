using System;
using System.Collections.Generic;

namespace Reminder.DB.Models
{
    public partial class UserTbl
    {
        public UserTbl()
        {
            CategoryTbls = new HashSet<CategoryTbl>();
            ReminderTbls = new HashSet<ReminderTbl>();
        }

        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<CategoryTbl> CategoryTbls { get; set; }
        public virtual ICollection<ReminderTbl> ReminderTbls { get; set; }
    }
}

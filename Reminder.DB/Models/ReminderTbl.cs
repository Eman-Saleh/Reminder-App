using System;
using System.Collections.Generic;

namespace Reminder.DB.Models
{
    public partial class ReminderTbl
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? CategoryId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ReminderDate { get; set; }

        public virtual CategoryTbl? Category { get; set; }
        public virtual UserTbl? CreatedByNavigation { get; set; }
    }
}

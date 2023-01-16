using System;
using System.Collections.Generic;

namespace Reminder.DB.Models
{
    public partial class CategoryTbl
    {
        public CategoryTbl()
        {
            InverseParent = new HashSet<CategoryTbl>();
            ReminderTbls = new HashSet<ReminderTbl>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CreatedBy { get; set; }
        public int? ParentId { get; set; }

        public virtual UserTbl? CreatedByNavigation { get; set; }
        public virtual CategoryTbl? Parent { get; set; }
        public virtual ICollection<CategoryTbl> InverseParent { get; set; }
        public virtual ICollection<ReminderTbl> ReminderTbls { get; set; }
    }
}

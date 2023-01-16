using Reminder.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DB.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IBaseRepository<UserTbl> UserTbls { get; }
        IBaseRepository<ReminderTbl> ReminderTbls { get; }
        IBaseRepository<CategoryTbl> CategoryTbls { get; }
        
        int Complete();
    }
}

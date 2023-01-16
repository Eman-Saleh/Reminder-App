using Reminder.DB.Interfaces;
using Reminder.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.BE.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;


        public IBaseRepository<UserTbl> UserTbls { get; private set; }

        public IBaseRepository<CategoryTbl> CategoryTbls { get; private set; }

        public IBaseRepository<ReminderTbl> ReminderTbls { get; private set; }

        public UnitOfWork (ApplicationDbContext context )
        { 
            _context = context;
            UserTbls = new BaseRepository<UserTbl>(_context);
            CategoryTbls = new BaseRepository<CategoryTbl>(_context);
            ReminderTbls = new BaseRepository<ReminderTbl>(_context);

        }
       

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
           _context.Dispose();
        }
    }
}

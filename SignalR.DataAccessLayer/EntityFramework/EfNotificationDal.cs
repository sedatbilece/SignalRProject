using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        private readonly SignalRContext _context;
        public EfNotificationDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public int CountByStatus(bool statusType)
        {
           return _context.Notifications.Where(x => x.Status == statusType).Count();
        }

        public List<Notification> GetAllNotificationByStatus(bool statusType)
        {
            return _context.Notifications.Where(x => x.Status == statusType).OrderByDescending(x=>x.Date).ToList();
        }
    }
}

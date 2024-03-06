using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {

        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public int CountByStatus(bool statusType)
        {
            return _notificationDal.CountByStatus(statusType);
        }

        public List<Notification> GetAllNotificationByStatus(bool statusType)
        {
            return _notificationDal.GetAllNotificationByStatus(statusType);
        }

        public void TAdd(Notification entity)
        {
            _notificationDal.Add(entity);
        }

        public void TDelete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public List<Notification> TGetAll()
        {
            return _notificationDal.GetAll();
        }

        public Notification TGetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public void TUpdate(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}

using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface INotificationDal :IGenereciDal<Notification>
    {

        int CountByStatus(bool statusType);
        List<Notification> GetAllNotificationByStatus(bool statusType);
        void  NotificationStatusChange(int id ,bool statusType);
    }
}

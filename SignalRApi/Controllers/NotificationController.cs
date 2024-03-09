using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_notificationService.TGetAll());
        }

        [HttpGet("CountByStatusFalse")]
        public IActionResult CountByStatusFalse()
        {
           return Ok(_notificationService.CountByStatus(false));
        }
        [HttpGet("GetAllByStatus")]
        public IActionResult GetAllByStatus()
        {
            return Ok(_notificationService.GetAllNotificationByStatus(false));
        }

        [HttpPost]
        public IActionResult Add(CreateNotificationDto notification)
        {
            _notificationService.TAdd(new Notification
            {
                Date = notification.Date,
                Description = notification.Description,
                Icon = notification.Icon,
                Status = notification.Status,
                Type = notification.Type
            });
            return Created("Created notification", notification);
        }

        [HttpPut]   
        public IActionResult Update(UpdateNotificationDto notification)
        {
            var notificationToUpdate = _notificationService.TGetById(notification.Id);
            if (notificationToUpdate == null)
            {
                return NotFound();
            }
            notificationToUpdate.Date = notification.Date;
            notificationToUpdate.Description = notification.Description;
            notificationToUpdate.Icon = notification.Icon;
            notificationToUpdate.Status = notification.Status;
            notificationToUpdate.Type = notification.Type;
            _notificationService.TUpdate(notificationToUpdate);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var notificationToDelete = _notificationService.TGetById(id);
            if (notificationToDelete == null)
            {
                return NotFound();
            }
            _notificationService.TDelete(notificationToDelete);
            return NoContent();
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
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


    }
}

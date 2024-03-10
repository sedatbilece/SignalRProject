using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.DefaultDtos;
using SignalRWebUI.Services;

namespace SignalRWebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly ConsumeService _consumeService;

        public MessageController(ConsumeService consumeService)
        {
            _consumeService = consumeService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new DefaultDto();
            var contactList = await _consumeService.ListContacts();
            model.Contact = contactList.FirstOrDefault();
            return View(model);
        }
    }
}

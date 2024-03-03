using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.DefaultDtos;
using SignalRWebUI.Services;
using System.Net.Http;

namespace SignalRWebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ConsumeService _consumeService;

        public BasketController(IHttpClientFactory httpClientFactory, ConsumeService consumeService)
        {
            _httpClientFactory = httpClientFactory;
            _consumeService = consumeService;
        }

        public async Task<IActionResult> Index()
        {
            var id = 6;
            var model = new DefaultDto();
            var client = _httpClientFactory.CreateClient();

            model.Baskets = await _consumeService.ListBaskets(id);

            var contactList = await _consumeService.ListContacts();
            model.Contact = contactList.FirstOrDefault();


            return View(model);
        }
    }
}

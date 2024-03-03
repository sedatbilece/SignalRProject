using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.DefaultDtos;
using SignalRWebUI.Services;
using System.Net.Http;
using System.Text;

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


        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7298/api/baskets/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return BadRequest();
        }

        
    }
}

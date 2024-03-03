using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.AboutDtos;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.DefaultDtos;
using SignalRWebUI.Dtos.DefaultDtos.SliderDtos;
using SignalRWebUI.Dtos.DiscountDtos;
using SignalRWebUI.Dtos.ProductDtos;
using SignalRWebUI.Services;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class DefaultController : Controller
	{
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ConsumeService _consumeService;

        public DefaultController(IHttpClientFactory httpClientFactory, ConsumeService consumeService)
        {
            _httpClientFactory = httpClientFactory;
            _consumeService = consumeService;
        }

        public async Task<IActionResult> Index()
		{
            var model = new DefaultDto();

            var client = _httpClientFactory.CreateClient();


            model.Sliders = await _consumeService.ListSliders();  
            model.Discounts = await _consumeService.ListDiscounts();
            model.Products = await _consumeService.ListProducts();
            model.Testimonials = await _consumeService.ListTestimonials();
            var aboutlist  = await _consumeService.ListAbouts();
            model.About = aboutlist.FirstOrDefault();
            var contactList = await _consumeService.ListContacts();
            model.Contact = contactList.FirstOrDefault();
           

            return View(model);
		}
        public async Task<IActionResult> Menu()
        {
            var model = new DefaultDto();
            var client = _httpClientFactory.CreateClient();

            model.ProductsWithCategory = await _consumeService.ListProductsWithCategory();
            model.Categories = await _consumeService.ListCategories();
            var contactList = await _consumeService.ListContacts();
            model.Contact = contactList.FirstOrDefault();


            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AddBasket(CreateBasketDto model)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7298/api/Basket", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> About()
        {
            return View();
        }
        public async Task<IActionResult> BookTable()
        {
            return View();
        }
    }
}

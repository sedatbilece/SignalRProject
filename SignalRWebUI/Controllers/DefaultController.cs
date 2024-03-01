using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.AboutDtos;
using SignalRWebUI.Dtos.DefaultDtos;
using SignalRWebUI.Dtos.DefaultDtos.SliderDtos;
using SignalRWebUI.Dtos.DiscountDtos;
using SignalRWebUI.Dtos.ProductDtos;
using SignalRWebUI.Services;

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
        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult BookTable()
        {
            return View();
        }
    }
}

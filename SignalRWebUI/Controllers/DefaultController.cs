using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.DefaultDtos;
using SignalRWebUI.Dtos.DefaultDtos.SliderDtos;

namespace SignalRWebUI.Controllers
{
	public class DefaultController : Controller
	{
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
		{
            var model = new DefaultDto();

            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7298/api/Sliders");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
                model.Sliders = values;
            }



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

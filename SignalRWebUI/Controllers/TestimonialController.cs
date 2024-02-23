using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.TestimonialDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{

	public class TestimonialController : Controller
	{

		private readonly IHttpClientFactory _httpClientFactory;

		public TestimonialController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{

			var client = _httpClientFactory.CreateClient();

			var response = await client.GetAsync("https://localhost:7298/api/Testimonial");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
				return View(values);
			}

			return View();
		}

		[HttpGet]
		public IActionResult CreateTestimonial()
		{

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto model)
		{
			model.Status = true;

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7298/api/Testimonial", content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> DeleteTestimonial(int id)
		{
			var client = _httpClientFactory.CreateClient();

			var response = await client.DeleteAsync($"https://localhost:7298/api/Testimonial/{id}");

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateTestimonial(int id)
		{
			var client = _httpClientFactory.CreateClient();

			var response = await client.GetAsync($"https://localhost:7298/api/Testimonial/{id}");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateTestimonialDto>(jsonData);
				return View(value);
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto model)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PutAsync("https://localhost:7298/api/Testimonial", content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}

	}
}

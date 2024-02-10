using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Dtos.ProductDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class ProductController : Controller
	{

		private readonly IHttpClientFactory _httpClientFactory;

		public ProductController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{

			var client = _httpClientFactory.CreateClient();

			var response = await client.GetAsync("https://localhost:7298/api/Product/ListWithCategory");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
				return View(values);
			}

			return View();
		}

		[HttpGet]
		public IActionResult CreateProduct()
		{

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto model)
		{
			model.Status = true;

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7298/api/Product", content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			var client = _httpClientFactory.CreateClient();

			var response = await client.DeleteAsync($"https://localhost:7298/api/Product/{id}");

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateProduct(int id)
		{
			var client = _httpClientFactory.CreateClient();

			var response = await client.GetAsync($"https://localhost:7298/api/Product/{id}");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
				return View(value);
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto model)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PutAsync("https://localhost:7298/api/Product", content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}
	}
}

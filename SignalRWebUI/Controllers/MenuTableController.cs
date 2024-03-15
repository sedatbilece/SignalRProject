using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.DtoLayer.MenuTableDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	[Authorize]
	public class MenuTableController : Controller
	{

		private readonly IHttpClientFactory _httpClientFactory;

		public MenuTableController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{

			var client = _httpClientFactory.CreateClient();

			var response = await client.GetAsync("https://localhost:7298/api/MenuTables");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(jsonData);
				return View(values);
			}

			return View();
		}

		
		public async Task<IActionResult> TableListByStatus()
		{

			var client = _httpClientFactory.CreateClient();

			var response = await client.GetAsync("https://localhost:7298/api/MenuTables");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(jsonData);
				return View(values);
			}

			return View();
		}

		[HttpGet]
		public IActionResult CreateMenuTable()
		{

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateMenuTable(CreateMenuTableDto model)
		{

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7298/api/MenuTables", content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> DeleteMenuTable(int id)
		{
			var client = _httpClientFactory.CreateClient();

			var response = await client.DeleteAsync($"https://localhost:7298/api/MenuTables/{id}");

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateMenuTable(int id)
		{
			var client = _httpClientFactory.CreateClient();

			var response = await client.GetAsync($"https://localhost:7298/api/MenuTables/{id}");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateMenuTableDto>(jsonData);
				return View(value);
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateMenuTable(UpdateMenuTableDto model)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PutAsync("https://localhost:7298/api/MenuTables", content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}
		

		[HttpGet]
		public async Task<IActionResult> ChangeMenuTableStatus(int id)
		{
			var client = _httpClientFactory.CreateClient();

			var response = await client.GetAsync($"https://localhost:7298/api/MenuTables/ChangeStatus/{id}");

			if (response.IsSuccessStatusCode)
			{
				
				//referer and return last page
				return Redirect(Request.Headers["Referer"].ToString());
			}

			return View();
		}

	}
}

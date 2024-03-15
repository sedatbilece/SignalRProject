﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SocialMediaDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	[Authorize]
	//SocialMedia
	public class SocialMediaController : Controller
	{

		private readonly IHttpClientFactory _httpClientFactory;

		public SocialMediaController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{

			var client = _httpClientFactory.CreateClient();

			var response = await client.GetAsync("https://localhost:7298/api/SocialMedia");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
				return View(values);
			}

			return View();
		}

		[HttpGet]
		public IActionResult CreateSocialMedia()
		{

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto model)
		{

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7298/api/SocialMedia", content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> DeleteSocialMedia(int id)
		{
			var client = _httpClientFactory.CreateClient();

			var response = await client.DeleteAsync($"https://localhost:7298/api/SocialMedia/{id}");

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateSocialMedia(int id)
		{
			var client = _httpClientFactory.CreateClient();

			var response = await client.GetAsync($"https://localhost:7298/api/SocialMedia/{id}");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateSocialMediaDto>(jsonData);
				return View(value);
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto model)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PutAsync("https://localhost:7298/api/SocialMedia", content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}

	}

}

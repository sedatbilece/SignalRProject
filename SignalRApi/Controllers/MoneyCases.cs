﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoneyCases : ControllerBase
	{
		private readonly IMoneyCaseService _moneyCaseService;

		public MoneyCases(IMoneyCaseService moneyCaseService)
		{
			_moneyCaseService = moneyCaseService;
		}


		[HttpGet]
		public IActionResult Get()
		{
			var moneyCases = _moneyCaseService.TotalMoneyCaseAmount();
			return Ok(moneyCases);
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{

		private readonly IOrderService _orderService;

		public OrdersController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet("TotalCount")]
		public IActionResult TotalCount()
		{
			var value = _orderService.TotalOrderCount();
			return Ok(value);
		}

		[HttpGet("ActiveCount")]
		public IActionResult ActiveCount()
		{
			var value = _orderService.ActiveOrderCount();
			return Ok(value);
		}

		[HttpGet("LastOrderPrice")]
		public IActionResult LastOrderPrice()
		{
			var value = _orderService.LastOrderPrice();
			return Ok(value);
		}


	}
}

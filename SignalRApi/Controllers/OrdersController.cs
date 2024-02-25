using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.OrderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{

		private readonly IOrderService _orderService;
		private readonly IMapper _mapper;

		public OrdersController(IOrderService orderService, IMapper mapper)
		{
			_orderService = orderService;
			_mapper = mapper;
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

		[HttpGet("TodayTotalPrice")]
		public IActionResult TodayTotalPrice()
		{
			var value = _orderService.TodayTotalPrice();
			return Ok(value);
		}

		[HttpGet]
		public IActionResult Get()
		{
			var values = _mapper.Map<List<ResultOrderDto>>(_orderService.TGetAll());
			return Ok(values);
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var value = _mapper.Map<GetOrderDto>(_orderService.TGetById(id));
			return Ok(value);
		}

		[HttpPut]
		public IActionResult Update([FromBody] UpdateOrderDto order)
		{
			var value = _mapper.Map<Order>(order);
			_orderService.TUpdate(value);
			return NoContent();
		}
		



	}
}

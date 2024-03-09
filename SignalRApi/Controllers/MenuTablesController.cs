using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTablesController : ControllerBase
	{
		private readonly IMenuTableService _menuTableService;
		private readonly IMapper _mapper;

		public MenuTablesController(IMenuTableService menuTableService, IMapper mapper)
		{
			_menuTableService = menuTableService;
			_mapper = mapper;
		}

		[HttpGet("Count")]
		public IActionResult Count()
		{
			return Ok(_menuTableService.MenuTableCount());
		}

		[HttpGet]
		public IActionResult List()
		{
			var values = _mapper.Map<List<ResultMenuTableDto>>(_menuTableService.TGetAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult Create(CreateMenuTableDto createMenuTableDto)
		{
			var value = _mapper.Map<MenuTable>(createMenuTableDto);
			_menuTableService.TAdd(value);

			return Ok("Created");
		}

		[HttpPut]
		public IActionResult Update(UpdateMenuTableDto updateMenuTableDto)
		{
			var value = _mapper.Map<MenuTable>(updateMenuTableDto);
			_menuTableService.TUpdate(value);

			return Ok("Updated");
		}
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var value = _menuTableService.TGetById(id);

			if (value == null)
				return NotFound();

			_menuTableService.TDelete(value);

			return Ok("Deleted");
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var value = _mapper.Map<GetMenuTableDto>(_menuTableService.TGetById(id));
			return Ok(value);
		}
	}
}

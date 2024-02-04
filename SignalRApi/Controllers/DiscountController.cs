using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IMapper mapper, IDiscountService discountService)
        {
            _mapper = mapper;
            _discountService = discountService;
        }

        [HttpGet]
        public IActionResult List()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateDiscountDto createDiscountDto)
        {
            var value = _mapper.Map<Discount>(createDiscountDto);
            _discountService.TAdd(value);

            return Ok("Created");
        }

        [HttpPut]
        public IActionResult Update(UpdateDiscountDto updateDiscountDto)
        {
            var value = _mapper.Map<Discount>(updateDiscountDto);
            _discountService.TUpdate(value);

            return Ok("Updated");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _discountService.TGetById(id);

            if (value == null)
                return NotFound();

            _discountService.TDelete(value);

            return Ok("Deleted");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _mapper.Map<GetDiscountDto>(_discountService.TGetById(id));
            return Ok(value);
        }
    }
}

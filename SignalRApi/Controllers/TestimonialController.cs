using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(IMapper mapper, ITestimonialService testimonialService)
        {
            _mapper = mapper;
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult List()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateTestimonialDto createTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TAdd(value);

            return Ok("Created");
        }

        [HttpPut]
        public IActionResult Update(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(value);

            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _testimonialService.TGetById(id);

            if (value == null)
                return NotFound();

            _testimonialService.TDelete(value);

            return Ok("Deleted");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _mapper.Map<GetTestimonialDto>(_testimonialService.TGetById(id));
            return Ok(value);
        }
    }
}

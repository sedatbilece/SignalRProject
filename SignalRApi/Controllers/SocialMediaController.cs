using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(IMapper mapper, ISocialMediaService socialMediaService)
        {
            _mapper = mapper;
            _socialMediaService = socialMediaService;
        }

        [HttpGet]
        public IActionResult List()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateSocialMediaDto createSocialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.TAdd(value);

            return Ok("Created");
        }

        [HttpPut]
        public IActionResult Update(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _socialMediaService.TUpdate(value);

            return Ok("Updated");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _socialMediaService.TGetById(id);

            if (value == null)
                return NotFound();

            _socialMediaService.TDelete(value);

            return Ok("Deleted");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _mapper.Map<GetSocialMediaDto>(_socialMediaService.TGetById(id));
            return Ok(value);
        }
    }
}

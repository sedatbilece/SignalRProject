using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {

        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }


        [HttpGet]
        public IActionResult List()
        {
            var values = _aboutService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateAboutDto createAboutDto)
        {
            var value = new About
            {
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                ImageUrl = createAboutDto.ImageUrl,
            };
            _aboutService.TAdd(value);

            return Ok("Created");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _aboutService.TGetById(id);

            if (value == null)
                return NotFound();

            _aboutService.TDelete(value);

            return Ok("Deleted");
        }


        [HttpPut]
        public IActionResult Update(UpdateAboutDto updateAboutDto)
        {
            var value = new About
            {
                Id = updateAboutDto.Id,
                Title = updateAboutDto.Title,
                Description = updateAboutDto.Description,
                ImageUrl = updateAboutDto.ImageUrl,
            };
            _aboutService.TUpdate(value);

            return Ok("Updated");
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           var value = _aboutService.TGetById(id);

            return Ok(value);
        }


    }
}

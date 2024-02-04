using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IMapper mapper, IContactService contactService)
        {
            _mapper = mapper;
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult List()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateContactDto createContactDto)
        {
            var value = _mapper.Map<Contact>(createContactDto);
            _contactService.TAdd(value);

            return Ok("Created");
        }

        [HttpPut]
        public IActionResult Update(UpdateContactDto updateContactDto)
        {
            var value = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(value);

            return Ok("Updated");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _contactService.TGetById(id);

            if (value == null)
                return NotFound();

            _contactService.TDelete(value);

            return Ok("Deleted");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _mapper.Map<GetContactDto>(_contactService.TGetById(id));
            return Ok(value);
        }
    }
}

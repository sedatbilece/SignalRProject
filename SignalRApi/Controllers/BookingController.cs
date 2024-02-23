using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }


        [HttpGet]
        public IActionResult List()
        {
            var values = _bookingService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateBookingDto createBookingDto)
        {
            var value = new Booking
            {
                Mail = createBookingDto.Mail,
                Date = createBookingDto.Date,
                Name = createBookingDto.Name,
                PersonCount = createBookingDto.PersonCount,
                Phone = createBookingDto.Phone,
            };
            _bookingService.TAdd(value);

            return Ok("Created");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _bookingService.TGetById(id);

            if (value == null)
                return NotFound();

            _bookingService.TDelete(value);

            return Ok("Deleted");
        }


        [HttpPut]
        public IActionResult Update(UpdateBookingDto updateBookingDto)
        {
            var value = new Booking
            {
                Id = updateBookingDto.Id,
                Mail = updateBookingDto.Mail,
                Date = updateBookingDto.Date,
                Name = updateBookingDto.Name,
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone,
            };
            _bookingService.TUpdate(value);

            return Ok("Updated");
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _bookingService.TGetById(id);

            return Ok(value);
        }


    }
}

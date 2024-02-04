using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IMapper mapper, IFeatureService featureService)
        {
            _mapper = mapper;
            _featureService = featureService;
        }

        [HttpGet]
        public IActionResult List()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Feature>(createFeatureDto);
            _featureService.TAdd(value);

            return Ok("Created");
        }

        [HttpPut]
        public IActionResult Update(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Feature>(updateFeatureDto);
            _featureService.TUpdate(value);

            return Ok("Updated");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _featureService.TGetById(id);

            if (value == null)
                return NotFound();

            _featureService.TDelete(value);

            return Ok("Deleted");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _mapper.Map<GetFeatureDto>(_featureService.TGetById(id));
            return Ok(value);
        }
    }
}

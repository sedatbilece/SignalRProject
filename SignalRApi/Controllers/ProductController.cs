using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult List()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(value);

            return Ok("Created");
        }

        [HttpPut]
        public IActionResult Update(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(value);

            return Ok("Updated");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _productService.TGetById(id);

            if (value == null)
                return NotFound();

            _productService.TDelete(value);

            return Ok("Deleted");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _mapper.Map<GetProductDto>(_productService.TGetById(id));
            return Ok(value);
        }
    }
}

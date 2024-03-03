using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly SignalRContext _context;
        public BasketsController(IBasketService basketService, SignalRContext context)
        {
            _basketService = basketService;
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetBasketByMenuTableNumber(int id)
        {
            var result = _basketService.GetBasketByMenuTableNumber(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult AddBasket(CreateBasketDto createBasketDto)
        {
            var price = _context.Products.FirstOrDefault(x => x.Id == createBasketDto.ProductId).Price;
            var count = 1;
             _basketService.TAdd(new SignalR.EntityLayer.Entities.Basket
            {
                Count=count,
                MenuTableId=6,
                Price = price,
                ProductId = createBasketDto.ProductId,
                TotalPrice = price * count
            });

                return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var result = _basketService.TGetById(id);
            if (result != null)
            {
                _basketService.TDelete(result);
                return Ok();
            }
            return BadRequest();
        }
    }
}

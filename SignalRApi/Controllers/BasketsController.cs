using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
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
    }
}

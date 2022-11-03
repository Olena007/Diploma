using Application.Interfaces;
using Application.Services;
using Domen.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.ModelsDTO;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BasketController : Controller
    {
        private readonly IBasketProvider _basketProvider;
        //private readonly JwtService _jwtService;

        //public BasketController(IBasketProvider basketProvider, JwtService jwtService)
        //{
        //    _basketProvider = basketProvider;
        //    _jwtService = jwtService;
        //}

        public BasketController(IBasketProvider basketProvider)
        {
            _basketProvider = basketProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Basket>>> GetAll()
        {
            var getAll = await _basketProvider.GetAll();

            return getAll;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Basket>> Get([FromRoute] int id)
        {
            var get = await _basketProvider.Get(id);

            return get;
        }

        [HttpPost("{id}")] 
        public ActionResult<Phone> Post ([FromRoute] int id)
        {
            try
            {
            if (id == null)
            {
                return BadRequest();
            }

            var basket = new Basket() { PhoneId = id, ComputerId = null,  ClientId = 1, Count = null };
             _basketProvider.Create(basket);

            return Ok(basket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var k = await _basketProvider.Delete(id);
                return Ok(k);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}

using Application.Interfaces;
using Domen.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BasketCompController : Controller
    {
        private readonly IBasketCompProvider _basketProvider;

        public BasketCompController(IBasketCompProvider basketProvider)
        {
            _basketProvider = basketProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasketComp>>> GetAll()
        {
            var getAll = await _basketProvider.GetAll();

            return getAll;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BasketComp>> Get([FromRoute] int id)
        {
            var get = await _basketProvider.Get(id);

            return get;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Computer>> Post([FromRoute] int id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }

                var basket = new BasketComp() { PhoneId = null, ComputerId = id, ClientId = 1, Count = null };
                await _basketProvider.Create(basket);

                return Ok(basket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
                var k = _basketProvider.Delete(id);
                return Ok(k);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

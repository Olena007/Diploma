using Application.Interfaces;
using Domen.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HistoryController : Controller
    {
        private readonly IHistoryProvider _historyProvider;

        public HistoryController(IHistoryProvider historyProvider)
        {
            _historyProvider = historyProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<History>>> GetAll()
        {
            var getAll = await _historyProvider.GetAll();

            return getAll;
        }

        [HttpPost("{id}")]
        public ActionResult<History> Post([FromRoute] int id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }

                var history = new History() { BasketId = id, BasketCompId = null };
                _historyProvider.Create(history);

                return Ok(history);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Comp/{id}")]
        public async Task<ActionResult<History>> PostComp([FromRoute] int id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }

                var history = new History() { BasketCompId = id };
                await _historyProvider.Create(history);

                return Ok(history);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            _historyProvider.Delete(id);
        }

    }
}

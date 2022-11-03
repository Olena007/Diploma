using Application.Interfaces;
using Domen.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.ModelsDTO;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComputerController : Controller
    {
        private IComputerProvider _computerProvider;

        public ComputerController(IComputerProvider computerProvider)
        {
            _computerProvider = computerProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Computer>>> GetAll()
        {
            var getAll = await _computerProvider.GetAll();

            return getAll;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Computer>> Get([FromRoute] int id)
        {
            var get = await _computerProvider.Get(id);

            return get;
        }

        [HttpGet("byName")]
        public async Task<ActionResult<IEnumerable<Computer>>> GetByName()
        {
            var byName = await _computerProvider.SortedByName();

            return byName;
        }

        [HttpGet("priseDesc")]
        public async Task<ActionResult<IEnumerable<Computer>>> GetByDesc()
        {
            var byPrice = await _computerProvider.SortedByPriseDesc();

            return byPrice;
        }

        [HttpGet("priseAsce")]
        public async Task<ActionResult<IEnumerable<Computer>>> GetByAsce()
        {
            var byPrice = await _computerProvider.SortedByPriseAsce();

            return byPrice;
        }

        [HttpPost]
        public async Task<ActionResult<Computer>> Post([FromBody] ComputerDto comp)
        {
            if (comp == null)
            {
                return BadRequest();
            }
            var p = new Computer() { ComputerId = comp.ComputerId, Name = comp.Name, Description = comp.Description, Url = comp.Url, Price = comp.Price };

            await _computerProvider.Post(p);

            return Ok(p);
        }

        [HttpPut]
        public async Task<ActionResult<Phone>> Put([FromBody] ComputerDto comp)
        {
            if (comp == null)
            {
                return BadRequest();
            }

            var p = new Computer() { ComputerId = comp.Id, Name = comp.Name, Description = comp.Description, Url = comp.Url, Price = comp.Price };

            await _computerProvider.Put(p);

            return Ok(p);
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            _computerProvider.Delete(id);
        }
    }
}

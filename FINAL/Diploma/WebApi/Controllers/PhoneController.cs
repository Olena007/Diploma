using Application.Interfaces;
//using Domen.Entities;
using Domen.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.ModelsDTO;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneController : Controller
    {
        private IPhoneProvider _phoneProvider;

        public PhoneController(IPhoneProvider phoneProvider)
        {
            _phoneProvider = phoneProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phone>>> GetAll()
        {
            var getAll = await _phoneProvider.GetAll();

            return getAll;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Phone>> Get([FromRoute] int id)
        {
            var get = await _phoneProvider.Get(id);

            return get;
        }

        [HttpGet("byName")]
        public async Task<ActionResult<IEnumerable<Phone>>> GetByName()
        {
            var byName = await _phoneProvider.SortedByName();

            return byName;
        }

        [HttpGet("priseDesc")]
        public async Task<ActionResult<IEnumerable<Phone>>> GetByDesc()
        {
            var byPrice = await _phoneProvider.SortedByPriseDesc();

            return byPrice;
        }

        [HttpGet("priseAsce")]
        public async Task<ActionResult<IEnumerable<Phone>>> GetByAsce()
        {
            var byPrice = await _phoneProvider.SortedByPriseAsce();

            return byPrice;
        }

        [HttpPost]
        public async Task<ActionResult<Phone>> Post([FromBody] PhoneDto phone)
        {
            if (phone == null)
            {
                return BadRequest();
            }
            var p = new Phone(){PhoneId = phone.PhoneId, Name = phone.Name, Description = phone.Description, Url = phone.Url, Price = phone.Price};
            await _phoneProvider.Post(p);

            return Ok(p);
        }

        [HttpPut]
        public async Task<ActionResult<Phone>> Put([FromBody] PhoneDto phone)
        {
            if (phone == null)
            {
                return BadRequest();
            }

            var p = new Phone() { PhoneId = phone.PhoneId, Name = phone.Name, Description = phone.Description, Url = phone.Url, Price = phone.Price };
            await _phoneProvider.Put(p);

            return Ok(p);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
               var k =  _phoneProvider.Delete(id);
                return Ok(k);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }


    }
}

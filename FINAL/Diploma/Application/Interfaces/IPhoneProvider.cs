//using Domen.Entities;
using Domen.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPhoneProvider
    {
        Task<ActionResult<IEnumerable<Phone>>> GetAll();

        Task<ActionResult<Phone>> Get(int id);

        Task<int> Post(Phone phone);

        Task Put(Phone Phone);

        Task Delete(int id);
        Task<ActionResult<IEnumerable<Phone>>> SortedByName();
        Task<ActionResult<IEnumerable<Phone>>> SortedByPriseAsce();
        Task<ActionResult<IEnumerable<Phone>>> SortedByPriseDesc();
    }
}

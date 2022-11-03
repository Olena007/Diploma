using Domen.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IComputerProvider
    {
        Task<ActionResult<IEnumerable<Computer>>> GetAll();

        Task<ActionResult<Computer>> Get(int id);

        Task<int> Post(Computer computer);

        Task Put(Computer computer);

        Task Delete(int id);
        Task<ActionResult<IEnumerable<Computer>>> SortedByName();
        Task<ActionResult<IEnumerable<Computer>>> SortedByPriseAsce();
        Task<ActionResult<IEnumerable<Computer>>> SortedByPriseDesc();
    }
}

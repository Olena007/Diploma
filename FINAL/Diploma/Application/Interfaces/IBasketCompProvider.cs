using Domen.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBasketCompProvider
    {
        Task<ActionResult<IEnumerable<BasketComp>>> GetAll();
        Task<ActionResult<BasketComp>> Get(int id);
        Task<int> Create(BasketComp basket);
        Task Delete(int id);
    }
}

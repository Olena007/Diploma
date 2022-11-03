using Domen.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBasketProvider
    {
        Task<ActionResult<IEnumerable<Basket>>> GetAll();
        Task<ActionResult<Basket>> Get(int id);
        Task<int> Create(Basket basket);
        Task<Basket> Delete(int id);
    }
}

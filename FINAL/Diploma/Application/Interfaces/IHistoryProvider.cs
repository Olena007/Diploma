using Domen.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IHistoryProvider
    {
        Task<ActionResult<IEnumerable<History>>> GetAll();
        Task<int> Create(History history);
        Task Delete(int id);

    }
}

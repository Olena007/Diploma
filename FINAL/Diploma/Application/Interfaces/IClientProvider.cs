using Domen.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClientProvider
    {
        Task<ActionResult<IEnumerable<Client>>> GetAll();
        Task<int> Create(Client client);
        Client GetByEmail(string email);
        Client GetById(int id);
    }
}

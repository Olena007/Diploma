using Application.Interfaces;
using BCrypt.Net;
using Domen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Providers
{
    public class ClientProvider : IClientProvider
    {
        private readonly IStoreContext _context;

        private int _idCount;

        public ClientProvider(IStoreContext context)
        {
            _context = context;
            _idCount = 1;

        }

        public async Task<int> Create(Client client)
        {
            var added = _context.Clients.Add(client);
            client.ClientId = await _context.SaveChangesAsync();

            _idCount++;
            return _idCount;

        }

        public async Task<ActionResult<IEnumerable<Client>>> GetAll()
        {
            var items = await _context.Clients.ToListAsync();

            if (items == null)
            {
                return null;
            }
            return items;
        }

        public Client GetByEmail(string email)
        {

            return _context.Clients.FirstOrDefault(u => u.Email == email);
        }

        public Client GetById(int id)
        {
            return _context.Clients.FirstOrDefault(c => c.ClientId == id);
        }

    }
}

using Application.Interfaces;
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
    public class ComputerProvider : IComputerProvider
    {
        private readonly IStoreContext _context;

        private int _idCount;

        public ComputerProvider(IStoreContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Computer>>> GetAll()
        {
            var items = await _context.Computers.ToListAsync();
            if (items == null)
            {
                return null;
            }
            return items;
        }

        public async Task<ActionResult<Computer>> Get(int id)
        {
            Computer comp = await _context.Computers.FirstOrDefaultAsync(x => x.ComputerId == id);
            if (comp == null)
            {
                return null;
            }

            return new ObjectResult(comp);
        }

        public async Task<int> Post(Computer comp)
        {
            comp.ComputerId = _idCount;
            var added = _context.Computers.Add(comp);
            comp.ComputerId =  await _context.SaveChangesAsync();

            _idCount++;
            return _idCount;

        }

        public async Task Put(Computer comp)
        {
            _context.Computers.Update(comp);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Computer comp = _context.Computers.FirstOrDefault(x => x.ComputerId == id);

            _context.Computers.Remove(comp);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Computer>>> SortedByName()
        {
            var items = await _context.Computers.OrderBy(p => p.Name).ToListAsync();
            if (items == null)
            {
                return null;
            }

            return items;
        }

        public async Task<ActionResult<IEnumerable<Computer>>> SortedByPriseAsce()
        {
            var items = await _context.Computers.OrderBy(p => p.Price).ToListAsync();
            if (items == null)
            {
                return null;
            }

            return items;
        }

        public async Task<ActionResult<IEnumerable<Computer>>> SortedByPriseDesc()
        {
            var items = await _context.Computers.OrderByDescending(p => p.Price).ToListAsync();
            if (items == null)
            {
                return null;
            }

            return items;
        }
    }
}


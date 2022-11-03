using Application.Interfaces;
//using Domen.Entities;
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
    public class PhoneProvider : IPhoneProvider
    {
        private readonly IStoreContext _context;

        private int _idCount;

        public PhoneProvider(IStoreContext context)
        {
           _context = context;
        }

        public async Task<ActionResult<IEnumerable<Phone>>> GetAll()
        {
            var items = await _context.Phones.ToListAsync();
            if (items == null)
            {
                return null;
            }
            return items;
        }

        public async Task<ActionResult<Phone>> Get(int id)
        {
            Phone phone = await _context.Phones.FirstOrDefaultAsync(x => x.PhoneId == id);
            if (phone == null)
            {
                return null;
            }

            return new ObjectResult(phone);
        }

        public async Task<int> Post(Phone phone)
        {
            phone.PhoneId = _idCount;
            var added = _context.Phones.Add(phone);
            phone.PhoneId = await _context.SaveChangesAsync();

           // _idCount++;
            return _idCount;

        }

        public async Task Put(Phone phone)
        {
            _context.Phones.Update(phone);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Phone phone = _context.Phones.FirstOrDefault(x => x.PhoneId == id);

            _context.Phones.Remove(phone);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Phone>>> SortedByName()
        {
            var items = await _context.Phones.OrderBy(p => p.Name).ToListAsync();
            if (items == null)
            {
                return null;
            }

            return items;
        }

        public async Task<ActionResult<IEnumerable<Phone>>> SortedByPriseAsce()
        {
            var items = await _context.Phones.OrderBy(p => p.Price).ToListAsync();
            if (items == null)
            {
                return null;
            }

            return items;
        }

        public async Task<ActionResult<IEnumerable<Phone>>> SortedByPriseDesc()
        {
            var items = await _context.Phones.OrderByDescending(p => p.Price).ToListAsync();
            if (items == null)
            {
                return null;
            }

            return items;
        }
    }
}

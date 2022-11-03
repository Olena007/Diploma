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
    public class BasketCompProvider : IBasketCompProvider
    {
        private readonly IStoreContext _context;

        private int _idCount;

        public BasketCompProvider(IStoreContext store)
        {
            _context = store;
            _idCount = 0;
        }
        public async Task<int> Create(BasketComp basket)
        {

            var added = _context.BasketComps.Add(basket);
            basket.BasketId = await _context.SaveChangesAsync();

            var i = basket.BasketId;

            _idCount++;
            return _idCount;
        }

        public async Task Delete(int id)
        {
            BasketComp basket = _context.BasketComps.FirstOrDefault(x => x.BasketId == id);

            _context.BasketComps.Remove(basket);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<BasketComp>>> GetAll()
        {
            var items = await _context.BasketComps.ToListAsync();

            if (items == null)
            {
                return null;
            }
            return items;
        }
        public async Task<ActionResult<BasketComp>> Get(int id)
        {
            BasketComp b = await _context.BasketComps.FirstOrDefaultAsync(x => x.BasketId == id);
            if (b == null)
            {
                return null;
            }

            return new ObjectResult(b);
        }
    }
}

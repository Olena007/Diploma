using Application.Interfaces;
using Domen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Providers
{
    public class BasketProvider : IBasketProvider
    {
        private readonly IStoreContext _context;

        private int _idCount;

        public BasketProvider(IStoreContext store)
        {
            _context = store;
            _idCount = 0;
        }
        public async Task<int> Create(Basket basket)
        {

            var added = _context.Baskets.Add(basket);
            basket.BasketId = await _context.SaveChangesAsync();

            var i = basket.BasketId;

            _idCount++;
            return _idCount;
        }

        public async Task<Basket> Delete(int id)
        {
            Basket basket = _context.Baskets.FirstOrDefault(x => x.BasketId == id);

            //var d = JsonConvert.SerializeObject(basket);
            _context.Baskets.Remove(basket);
            await _context.SaveChangesAsync();
            return basket;

        }

        public async Task<ActionResult<IEnumerable<Basket>>> GetAll()
        {
            var items = await _context.Baskets.ToListAsync();

            if (items == null)
            {
                return null;
            }
            return items;
        }
        public async Task<ActionResult<Basket>> Get(int id)
        {
            Basket b = await _context.Baskets.FirstOrDefaultAsync(x => x.BasketId == id);
            if (b == null)
            {
                return null;
            }

            return new ObjectResult(b);
        }


    }
}

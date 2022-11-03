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
    public class HistoryProvider : IHistoryProvider
    {
        private readonly IStoreContext _context;
        private int _idCount;
        public HistoryProvider(IStoreContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<History>>> GetAll()
        {
            var items = await _context.Histories.ToListAsync();

            if (items == null)
            {
                return null;
            }
            return items;
        }

        public async Task<int> Create(History history)
        {

            var added = _context.Histories.Add(history);
            history.HistoryId = await _context.SaveChangesAsync();

            var i = history.HistoryId;

            _idCount++;
            return _idCount;
        }

        public async Task Delete(int id)
        {
            History h = _context.Histories.FirstOrDefault(x => x.HistoryId == id);

            _context.Histories.Remove(h);
            await _context.SaveChangesAsync();
        }
    }
}

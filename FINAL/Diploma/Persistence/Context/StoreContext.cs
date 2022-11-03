using Application.Interfaces;
using Domen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class StoreContext : DbContext, IStoreContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
        : base(options)
        {
        }

        public DbSet<History> Histories { get; set; }
        public DbSet<BasketComp> BasketComps { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Phone> Phones { get; set; }
        
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}

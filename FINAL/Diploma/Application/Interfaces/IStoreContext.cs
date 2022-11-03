using Domen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IStoreContext
    {
        DbSet<History> Histories { get; set; }
        DbSet<BasketComp> BasketComps { get; set; }
        DbSet<Basket> Baskets { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Computer> Computers { get; set; }
        DbSet<Phone> Phones { get; set; }

        Task<int> SaveChangesAsync();
    }
}

using CoffeeShopApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopApi.Data
{
    public class CoffeeShopApiDbContext : DbContext
    {
        public CoffeeShopApiDbContext(DbContextOptions<CoffeeShopApiDbContext>options) : base(options) { }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Reservation> Reservation {get; set;}
        public DbSet<SubMenu> SubMenu { get; set; }
    }
}

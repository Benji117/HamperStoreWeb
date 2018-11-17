using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HamperStoreWeb.DataAcess.Models;

namespace HamperStoreWeb.DataAcess.Models
{
    public class HamperStoreEntities : DbContext
    {
        public HamperStoreEntities(DbContextOptions<HamperStoreEntities> options)
            : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product>  Products { get; set; }
        public DbSet<Hamper>  Hampers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=HamperStoreWebDb; Trusted_Connection=True");
        }
    }
}

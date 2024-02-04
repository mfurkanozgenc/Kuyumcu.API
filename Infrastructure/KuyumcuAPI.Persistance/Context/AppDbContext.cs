using Azure.Core;
using KuyumcuAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Persistance.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Sale>  Sales{ get; set; }
        public DbSet<SalesProduct>  SalesProducts{ get; set; }
        public DbSet<ProductSales>  ProductSales{ get; set; }
        public DbSet<Customer>   Customers{ get; set; }
        public DbSet<User>   Users{ get; set; }
        public DbSet<CashTransaction>   CashTransactions{ get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

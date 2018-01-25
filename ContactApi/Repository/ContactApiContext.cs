using ContactApi.Models;
using ContactApi.Models.ModelConfiguration;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContactApi.Repository
{
    public class ContactApiContext: DbContext
    {
        
        public ContactApiContext(DbContextOptions<ContactApiContext> options): base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
        }
    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoppingApi
{
    public class ShoppingDBContext : DbContext
    {
        public ShoppingDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CustomerItem> CustomerItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ARIS-M;Initial Catalog=ShoppingApiDatabase;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CustomerItem>().HasKey(ci => new { ci.CustomerId, ci.ItemId });

            List<Category> categories = new List<Category>()
            {
                new Category { Id = 1, Name = "Kendaraan"},
                new Category { Id = 2, Name = "makanan"},

            };

            List<Item> items = new List<Item>()
            {
                new Item() { Id = 1, Name = "Beat", Price = 12000000, CategoryId = categories[0].Id },
                new Item() { Id = 2, Name = "N-Max", Price = 32000000, CategoryId = categories[0].Id },
                new Item() { Id = 3, Name = "Sarimie", Price = 1200, CategoryId = categories[1].Id },
                new Item() { Id = 4, Name = "AQUA", Price = 3500, CategoryId = categories[1].Id }
            };

            List<Detail> details = new List<Detail>()
            {
                new Detail { Id = items[0].Id, Weight = 20, Description = "Second"},
                new Detail { Id = items[1].Id, Weight = 30, Description = "Baru"},
                new Detail { Id = items[2].Id, Weight = 3, Description = "1 Dus"},
                new Detail { Id = items[3].Id, Weight = 13, Description = "1 Dus"},
            };

            List<Customer> customers = new List<Customer>()
            {
                new Customer { Id = 1, Name = "Maria", Age = 30},
                new Customer { Id = 2, Name = "Mahmud", Age = 20},
            };

            List<CustomerItem> customerItems = new List<CustomerItem>()
            {
                new CustomerItem { Id = 1, CustomerId = customers[0].Id, ItemId = items[0].Id },
                new CustomerItem { Id = 2, CustomerId = customers[0].Id, ItemId = items[2].Id },
                new CustomerItem { Id = 3, CustomerId = customers[0].Id, ItemId = items[3].Id },
                new CustomerItem { Id = 4, CustomerId = customers[1].Id, ItemId = items[0].Id },
                new CustomerItem { Id = 5, CustomerId = customers[1].Id, ItemId = items[1].Id },
                new CustomerItem { Id = 6, CustomerId = customers[1].Id, ItemId = items[3].Id },
            };

            //modelBuilder.Entity<Category>(c =>
            //    {
            //        c.HasData(categories);
            //        c.OwnsMany(i => i.Items).HasData(
            //                new Item() { Id = 1, Name = "Beat", Price = 12000000},
            //                new Item() { Id = 2, Name = "N-Max", Price = 32000000 },
            //                new Item() { Id = 3, Name = "Sarimie", Price = 1200 },
            //                new Item() { Id = 4, Name = "AQUA", Price = 3500 }
            //            );
            //    }
            //);

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Detail>().HasData(details);
            modelBuilder.Entity<CustomerItem>().HasData(customerItems);
            modelBuilder.Entity<Customer>().HasData(customers);
            modelBuilder.Entity<Item>().HasData(items);
            //    modelBuilder.Entity<ItemsDetail>()
            //        .HasKey(d => d.Id);

            //    modelBuilder.Entity<Item>()
            //        .HasOptional(i => i.ItemsDetail)
            //        .WithRequired(d => d.Item);

            //modelBuilder.Entity<Item>()
            //    .HasMany(t => t.Customers)
            //    .WithMany(t => t.Items)
            //    .Map(m =>
            //    {
            //        m.ToTable("ItemsCustomers");
            //        m.MapLeftKey("ItemId");
            //        m.MapRightKey("CustomerId");
            //    });


            base.OnModelCreating(modelBuilder);
        }
    }
}
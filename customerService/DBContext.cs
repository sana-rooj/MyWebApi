using customerService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customerService
{
    public class DBContext : DbContext
    {


        public DBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
                new Product
                {
                    Product_Id = 1,
                    Product_Name = "Pasta",
                    Product_Des ="white sause",
                    Product_Price =  880,
                    Product_Tax = 50
                },
                 new Product
                 {
                     Product_Id = 2,
                     Product_Name = "Chicken",
                     Product_Des = "grilled",
                     Product_Price = 880,
                     Product_Tax = 50
                 },
                  new Product
                  {
                      Product_Id = 3,
                      Product_Name = "Burger",
                      Product_Des = "labaniese sause",
                      Product_Price = 880,
                      Product_Tax = 50
                  },
                   new Product
                   {
                       Product_Id = 4,
                       Product_Name = "stake",
                       Product_Des = "chicken maushroom sause",
                       Product_Price = 880,
                       Product_Tax = 50
                   },
                    new Product
                    {
                        Product_Id = 5,
                        Product_Name = "pizza",
                        Product_Des = "BBQ",
                        Product_Price = 880,
                        Product_Tax = 50
                    }





                );
           // base.OnModelCreating(builder);
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order_Products> Orders_Products { get; set; }
       

    }

}

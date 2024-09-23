using De_Friet_Tent.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De_Friet_Tent.DB
{
    public class Friesshopdb : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Owner> Owner { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = @"Data Source=.;Initial Catalog=DeFrietTent; Integrated Security=true;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // specificeer
            modelBuilder.Entity<Product>()
                .Property(P => P.Name)
                .HasMaxLength(30);

            modelBuilder.Entity<Category>()
                .Property(Ca => Ca.Name)
                .HasMaxLength(30);

            modelBuilder.Entity<Employee>()
                .Property(E => E.Firstname)
                .HasMaxLength(30);

            modelBuilder.Entity<Employee>()
                .Property(E => E.Lastname)
                .HasMaxLength(50);

            modelBuilder.Entity<Customer>()
                .Property(Cu => Cu.Firstname)
                .HasMaxLength(30);

            modelBuilder.Entity<Customer>()
                .Property(Cu => Cu.Lastname)
                .HasMaxLength(50);

            modelBuilder.Entity<Owner>()
                .Property(O => O.Firstname)
                .HasMaxLength(30);

            modelBuilder.Entity<Owner>()
                .Property(O => O.Lastname)
                .HasMaxLength(50);

            // data seed
            Product FirstProductEntity = new Product()
            {
                Id = 1,
                Name = "Kaas",
                Price = 4.56,
                Amount = 17,
                categoryId = 1,


            };

            Category FirstCategoryEntity = new Category()
            {
                Id = 1,
                Name = "Zuivel"
            };

            Owner FOwnerEntity = new Owner()
            {
                Id = 1,
                Firstname = "Frank",
                Lastname = "Pieter",
                Phonenumber = "0632456789",
                Emailaddress = "Owner@Frietshop.com",
                Address = "Ownerlaan 3",

            };

            Employee FEmployeeEntity = new Employee()
            {
                Id = 2,
                Firstname = "Fran",
                Lastname = "Piet",
                Phonenumber = "0632456779",
                Emailaddress = "EmployeeFran@Frietshop.com",
                Address = "Employeelaan 4",

            };

            modelBuilder.Entity<Employee>()
                 .HasData(FEmployeeEntity);

            modelBuilder.Entity<Owner>()
                .HasData(FOwnerEntity);

            modelBuilder.Entity<Product>()
                .HasData(FirstProductEntity);

            modelBuilder.Entity<Category>()
                .HasData(FirstCategoryEntity);
        }
        public DbSet<De_Friet_Tent.Models.Order> Order { get; set; } = default!;

    }
}

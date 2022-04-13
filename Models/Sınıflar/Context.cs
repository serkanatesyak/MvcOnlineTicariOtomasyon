using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Recipt> Recipts { get; set; }
        public DbSet<ReciptDetail> ReciptDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SalesMove> SalesMoves { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<CargoTracking> CargoTrackings { get; set; }
        public DbSet<CargoDetails> CargoDetailss { get; set; }
        public DbSet<Message> Messages { get; set; }



    }
}
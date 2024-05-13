using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListApp.Models
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        {
        }

        public DbSet<ToDoList> ToDoLists { get; set; } = null;
        public DbSet<Status> ToDoListStatuses { get; set; } = null;
        public DbSet<Category> ToDoListCategories { get; set; } = null;

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Category>().HasData(
                new Category { CategoryId = "work", CategoryName = "Work" },
                new Category { CategoryId = "home", CategoryName = "Home" },
                new Category { CategoryId = "ex", CategoryName = "Excercise" },
                new Category { CategoryId = "shop", CategoryName = "Shopping" },
                new Category { CategoryId = "call", CategoryName = "Contact" }
                );
            model.Entity<Status>().HasData(
                new Status { StatusId = "open", StatusName = "Open"},
                new Status { StatusId = "done", StatusName = "Completed"}
                );
            model.Entity<ToDoList>().HasKey(
                e => e.ListId
                );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcApplication4.Models;

namespace MvcApplication4.Data_Access_Layer
{
    public class SalesERPDAL : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        { 
            modelBuilder.Entity<Employee>().ToTable("TblEmployee");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
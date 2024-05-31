using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MvcDemo4.DAL.Entity;
using MvcDemo4.DAL.Extend;

namespace MvcDemo4.DAL.Database
{
   
    public   class DbContainer : IdentityDbContext<ApplicationUser>
    {
        public DbContainer(DbContextOptions<DbContainer> options):base(options)
        {


        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server= FAROUKMAHMOUD\\SQLEXPRESS ; Database= MvcRoute20230212 ; Integrated Security =true");
        //}


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server =FAROUKMAHMOUD\\SQLEXPRESS ; Database= MvcRoute20230212  ; Integrated Security =true");
        //}

        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainer> Trainer { get; set; }

    }
}

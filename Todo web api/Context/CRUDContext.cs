using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo_web_api.Models;

namespace Todo_web_api.Context
{
    public class CRUDContext : DbContext 
    {

        public CRUDContext(DbContextOptions<CRUDContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Usertask> Usertasks { get; set; }
        public DbSet<Sign_up> Sign_Ups { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LightFeather.Models
{
    public class SupervisorContext : DbContext 
    {
        public SupervisorContext(DbContextOptions<SupervisorContext> options) : base(options)
        {
        }

        public DbSet<Supervisor> Supervisors { get; set; }
    }
}

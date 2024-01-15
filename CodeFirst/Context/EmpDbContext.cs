using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CodeFirst.Context
{
    public class EmpDbContext : DbContext
    {
        public EmpDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("localConnection"));
        }

        public virtual DbSet<Designation> Designations { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}

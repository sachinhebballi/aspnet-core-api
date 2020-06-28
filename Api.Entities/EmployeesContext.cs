using Api.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Entities
{
    public class EmployeesContext : DbContext
    {
        public EmployeesContext(DbContextOptions<EmployeesContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne<Address>(a => a.Address)
                .WithOne(p => p.Employee);
        }
    }
}

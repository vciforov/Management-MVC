using Microsoft.EntityFrameworkCore;
using ProjectMVC.Models;

namespace ProjectMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeProject>().HasKey(ep => new
            {
                ep.EmployeeId,
                ep.ProjectId

            });
            modelBuilder.Entity<EmployeeProject>()
                .HasOne(p => p.Project)
                .WithMany(ep => ep.EmployeeProjects)
                .HasForeignKey(p => p.ProjectId);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(e => e.Employee)
                .WithMany(ep => ep.EmployeeProjects)
                .HasForeignKey(e => e.EmployeeId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }    

    }
}

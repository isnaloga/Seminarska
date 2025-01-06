using IS_nal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IS_nal.Data
{
    public class FitnesContext : IdentityDbContext<ApplicationUser>
    {
        public FitnesContext(DbContextOptions<FitnesContext> options)
            : base(options)
        {
        }

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Trainer>().ToTable("Trainer");
            modelBuilder.Entity<Plan>().ToTable("Plan");
            modelBuilder.Entity<Customer>().ToTable("Customer");
        }
    }
}
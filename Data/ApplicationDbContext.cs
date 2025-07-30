using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagement02.Models;

namespace UserManagement02.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SectionManager> SectionManager { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Trainee>()
                .HasOne(t => t.Supervisor)
                .WithMany(s => s.Trainees)
                .HasForeignKey(t => t.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Trainee>()
                .HasOne(t => t.Department)
                .WithMany(d => d.Trainees)
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Department>()
                .HasOne(d => d.Supervisor)
                .WithOne()
                .HasForeignKey<Department>(d => d.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Supervisor>()
                .HasOne(s => s.AppUser)
                .WithMany()
                .HasForeignKey(s => s.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SectionManager>()
                .HasOne(sm => sm.AppUser)
                .WithMany()
                .HasForeignKey(sm => sm.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SectionManager>()
                .HasOne(sm => sm.Department)
                .WithOne(d => d.SectionManager)
                .HasForeignKey<SectionManager>(sm => sm.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

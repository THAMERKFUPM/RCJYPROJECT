using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagement02.Models;

<<<<<<< HEAD
namespace UserManagement02.Data
{
    public class ApplicationDbContext
        : IdentityDbContext<IdentityUser, IdentityRole, string>
=======
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagement02.Models;

namespace UserManagement02.Data
{
    public class ApplicationDbContext
        : IdentityDbContext<AppUser, IdentityRole, string>
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

<<<<<<< HEAD
        public DbSet<AppUser>     AppUsers    { get; set; }
        public DbSet<Supervisor>  Supervisors { get; set; }
        public DbSet<Trainee>     Trainee    { get; set; }
        public DbSet<Department>  Departments { get; set; }

        /*protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Department>(b =>
            {
                b.HasKey(d => d.Id);
                b.Property(d => d.Name)
                 .IsRequired()
                 .HasMaxLength(200);

                b.HasData(
                    new Department { Id = 1, Name = "تقنية المعلومات"        },
                    new Department { Id = 2, Name = "استثمار الأملاك"            },
                    new Department { Id = 3, Name = "البيئة"                    },
                    new Department { Id = 4, Name = "العقود"                    },
                    new Department { Id = 5, Name = "التطوير والاستثمار"        },
                    new Department { Id = 6, Name = "الشؤون الفنية"            },
                    new Department { Id = 7, Name = "خدمات المدينة"            },
                    new Department { Id = 8, Name = "المشاريع"                  },
                    new Department { Id = 9, Name = "الأمن الصناعي والسلامة"   }
                );
            });

            builder.Entity<Supervisor>(b =>
            {
                b.HasKey(s => s.SupervisorID);

                
                b.Property(s => s.DepartmentId)
                 .IsRequired();

                b.HasOne(s => s.Department)
                 .WithMany()    
                 .HasForeignKey(s => s.DepartmentId)
                 .OnDelete(DeleteBehavior.Restrict);
            });
        }*/
    }
}
=======
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SectionManager> SectionManager { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Trainee>()
                .HasOne(t => t.Supervisor)
                .WithMany(s => s.Trainee)
                .HasForeignKey(t => t.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Trainee>()
                .HasOne(t => t.Department)
                .WithMany(d => d.Trainee)
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
                .WithMany(d => d.SectionManager)
                .HasForeignKey(sm => sm.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587

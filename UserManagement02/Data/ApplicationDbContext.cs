using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagement02.Models;

namespace UserManagement02.Data
{
    public class ApplicationDbContext
        : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<AppUser>     AppUsers    { get; set; }
        public DbSet<Supervisor>  Supervisors { get; set; }
        public DbSet<Trainee>     Trainees    { get; set; }
        public DbSet<Department>  Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ——— Departments seed ————————————————————————
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

            // ——— Supervisors → Department FK ———————————————————
            builder.Entity<Supervisor>(b =>
            {
                b.HasKey(s => s.SupervisorID);

                // ensure CLR has this property:
                b.Property(s => s.DepartmentId)
                 .IsRequired();

                b.HasOne(s => s.Department)
                 .WithMany()    // or .WithMany(d => d.Supervisors)
                 .HasForeignKey(s => s.DepartmentId)
                 .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}

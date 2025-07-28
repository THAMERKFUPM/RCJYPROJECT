using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManagement02;
using UserManagement02.Data;
<<<<<<< HEAD
using UserManagement02.Interfaces;
using UserManagement02.Mapping;
using UserManagement02.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1) EF Core + SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 2) Identity
builder.Services
    .AddDefaultIdentity<IdentityUser>(opts => {
=======
using UserManagement02.Mapping;
using UserManagement02.Models;
using UserManagement02.Repositories;
using UserManagement02.Interfaces;
using UserManagement02.Services;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services
    .AddDefaultIdentity<AppUser>(opts =>
    {
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
        opts.SignIn.RequireConfirmedAccount = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

<<<<<<< HEAD
// 3) app services
builder.Services.AddScoped<ISupervisorRepo,  SupervisorRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<ITraineeRepo,     TraineeRepo>();
builder.Services.AddScoped<IDepartmentRepo,   DepartmentRepo>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

// 4) MVC & Razor Pages
=======
// Repositories
builder.Services.AddScoped<ISupervisorRepo,  SupervisorRepo>();
builder.Services.AddScoped<IUserRepo,        UserRepo>();
builder.Services.AddScoped<ITraineeRepo,     TraineeRepo>();
builder.Services.AddScoped<IDepartmentRepo,  DepartmentRepo>();

// Services
builder.Services.AddScoped<ITraineeScopeService, TraineeScopeService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// MVC and  Razor
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

<<<<<<< HEAD
// 5) pipeline
if (app.Environment.IsDevelopment())
    app.UseMigrationsEndPoint();
else
    app.UseExceptionHandler("/Home/Error");
=======

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


// ─── SEEDING ──────────────────────────────────────────────────────
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    //  Migrate
    var ctx = services.GetRequiredService<ApplicationDbContext>();
    ctx.Database.Migrate();

    // Seed Roles
    var roleMgr = services.GetRequiredService<RoleManager<IdentityRole>>();
    string[] roles = new[] { "موارد بشرية", "مشرف قسم", "رئيس القسم", "متدرب", "مدير نظام" };
    foreach (var r in roles)
        if (!await roleMgr.RoleExistsAsync(r))
            await roleMgr.CreateAsync(new IdentityRole(r));

    //  Seed Departments 
    if (!ctx.Departments.Any())
    {
        ctx.Departments.AddRange(
            new Department { DepartmentName = "التطبيقات" },
            new Department { DepartmentName = "الشبكات" },
            new Department { DepartmentName = "العقود" },
            new Department { DepartmentName = "الصناعات الخفيفة" }
        );
        ctx.SaveChanges();
    }
}


>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
<<<<<<< HEAD
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
=======
    pattern: "{controller=Home}/{action=Index}/{id?}");
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
app.MapRazorPages();

app.Run();
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManagement02;
using UserManagement02.Data;
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
        opts.SignIn.RequireConfirmedAccount = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

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
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();


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



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
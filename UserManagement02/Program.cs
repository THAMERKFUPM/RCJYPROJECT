using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManagement02;
using UserManagement02.Data;
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
        opts.SignIn.RequireConfirmedAccount = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// 3) app services
builder.Services.AddScoped<ISupervisorRepo,  SupervisorRepo>();
builder.Services.AddScoped<ITraineeRepo,     TraineeRepo>();
builder.Services.AddScoped<IDepartmentRepo,   DepartmentRepo>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

// 4) MVC & Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// 5) pipeline
if (app.Environment.IsDevelopment())
    app.UseMigrationsEndPoint();
else
    app.UseExceptionHandler("/Home/Error");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.MapRazorPages();

app.Run();
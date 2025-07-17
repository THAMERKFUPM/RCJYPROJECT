using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
builder.Services.AddScoped<IUserRepo,        UserRepo>();
builder.Services.AddScoped<ITraineeRepo,     TraineeRepo>();
builder.Services.AddScoped<IDepartmentRepo,   DepartmentRepo>();

// 4) AutoMapper + validate its configuration
builder.Services.AddAutoMapper(typeof(MappingProfile));
// Build a temporary service provider to resolve IMapper:
var sp     = builder.Services.BuildServiceProvider();
var mapper = sp.GetRequiredService<IMapper>();
// Throws on startup if any ForMember maps to a nonexistent member:
mapper.ConfigurationProvider.AssertConfigurationIsValid();

// 5) MVC & Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// 6) middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

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
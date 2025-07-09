using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManagement02;
using UserManagement02.Data;
using UserManagement02.Repositories;

var builder = WebApplication.CreateBuilder(args);

// EF + SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddTransient<IUserRepo,UserRepo>();

// Identity default (no custom AppRole)
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// MVC + Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Transint repo
builder.Services.AddTransient<ISupervisorRepo, SupervisorRepo>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseMigrationsEndPoint();
else
    app.UseExceptionHandler("/Home/Error");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// default route + razor pages
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
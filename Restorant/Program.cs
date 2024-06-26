using Microsoft.EntityFrameworkCore;
using Restorant.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IdentityDataContext>(Options =>
{
    var configuration = builder.Configuration.GetConnectionString("mysql_connection");
    var version = new MySqlServerVersion(new Version(8, 0, 36));
    Options.UseMySql(configuration, version);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Musteri",
    pattern: "{area:exists}/{controller=Musteri1}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Garson",
    pattern: "{area:exists}/{controller=Garson}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Mutfak",
    pattern: "{area:exists}/{controller=Mutfak}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

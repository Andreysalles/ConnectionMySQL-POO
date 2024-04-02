using Microsoft.EntityFrameworkCore;
using MySqlConnectionPOO.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Contexto>(
    options => options.UseMySql("server=localhost;initial catalog=MYSQL_CONNECTION;uid=root;pwd=andrey-dba",
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql")
    ));
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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
       name: "User",
       pattern: "User/{action=Index}/{id?}",
       defaults: new { controller = "User" });

app.MapControllerRoute(
    name: "Address",
    pattern: "Address/{action=Index}/{id?}",
    defaults: new { controller = "Address" });

app.Run();

using FreshMartPortal.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? builder.Configuration.GetConnectionString("FreshMartConnection");

builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseSession();

app.Use(async (context, next) =>
{
    var path = context.Request.Path.Value?.ToLower() ?? "";
    var loggedIn = context.Session.GetString("UserLoggedIn") == "true";

    var publicPage =
        path == "/" ||
        path == "/index" ||
        path.StartsWith("/login") ||
        path.StartsWith("/css") ||
        path.StartsWith("/js") ||
        path.StartsWith("/lib");

    if (!loggedIn && !publicPage)
    {
        context.Response.Redirect("/Login");
        return;
    }

    await next();
});

app.MapRazorPages();

app.Run();
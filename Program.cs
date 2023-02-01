using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;
using MovieTickets.Data.Cart;
using MovieTickets.Data.Services;
using MovieTickets.Models;

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
builder.Services.AddControllersWithViews();

// DbContext Configuration
builder.Services.AddDbContext<AppDbContext>(
            options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")));

// Services Configuration
//builder.Services.AddScoped<AppDbContext,AppDbContext>();
builder.Services.AddScoped<IActorsService, ActorsService>();
builder.Services.AddScoped<IProducersService, ProducersService>();
builder.Services.AddScoped<ICinemasService, CinemasService>();
builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));
builder.Services.AddSession();

//Authentication and Authorization
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
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
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

AppDbInitializer.Seed(app);
AppDbInitializer.SeedUsersAndRoles(app).Wait();

app.Run();

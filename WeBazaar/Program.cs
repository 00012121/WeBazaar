using WeBazaar.Data.Enums;
using WeBazaar.Data;
using Microsoft.EntityFrameworkCore;
using WeBazaar.Data.Services;
using WeBazaar.Data.Cart;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



//DbContext configuration
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));


//Services configuration
builder.Services.AddScoped<IProductsService, ProductsService>();

builder.Services.AddScoped<IProducersService, ProducersService>();

builder.Services.AddScoped<ICompaniesService, CompaniesService>();

builder.Services.AddScoped<IItemsService, ItemsService>();

builder.Services.AddSingleton<IHttpContextAccessor,  HttpContextAccessor>();
builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));
builder.Services.AddSession();

builder.Services.AddScoped<IOrdersService, OrdersService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//Seed database
//AppDbInitializer.Seed(app);

app.Run();


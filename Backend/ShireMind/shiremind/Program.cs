// var builder = WebApplication.CreateBuilder(args);
//
// // Add services to the container.
// builder.Services.AddControllersWithViews();
//
// var app = builder.Build();
//
// // Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Home/Error");
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }
//
// app.UseHttpsRedirection();
// app.UseRouting();
//
// app.UseAuthorization();
//
// app.MapStaticAssets();
//
// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}")
//     .WithStaticAssets();
//
//
// app.Run();


using Microsoft.EntityFrameworkCore;
using shiremind.Data; // Your DbContext namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ✅ Add EF Core and SQL Server support
builder.Services.AddDbContext<ShireMindDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Required for wwwroot

app.UseRouting();

app.UseAuthorization();

// ✅ Add API routes + MVC fallback
app.MapControllers(); // <--- This maps your API controllers like UserController

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
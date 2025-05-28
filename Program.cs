using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Music_Store_Warehouse_App.Data;
using Music_Store_Warehouse_App.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Music_Store_Warehouse_AppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Music_Store_Warehouse_AppContext") ?? throw new InvalidOperationException("Connection string 'Music_Store_Warehouse_AppContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// -- Seed Data --
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Instruments}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

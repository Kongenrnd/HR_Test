using HumanResources.Data;
using HumanResources.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .Build();


var connectionString = configuration.GetConnectionString(
    "DefaultConnection");

//connectionString = "Data Source=desktop-f8382e1;Initial Catalog=HRDB;Integrated Security=True;Trust Server Certificate=True;";
builder.Services.AddDbContext<HumanResourcesContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IHRRepository, HRRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
else
{
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using System.Text;
using HumanResources.Data;
using HumanResources.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
// 設定 Cookie 認證
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index"; // 登入頁面
        options.LogoutPath = "/Login/Logout"; // 登出頁面
        options.AccessDeniedPath = "/Home/Index"; // 訪問拒絕頁面
    });
// 添加授權服務
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("NormalUserOnly", policy => policy.RequireRole("NormalUser"));
});
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

//設定授權&認證
app.UseAuthorization();
app.UseAuthentication();
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

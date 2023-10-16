using Microsoft.EntityFrameworkCore;
using SimpleEmpCRUDAJAX.Models;
using SimpleEmpCRUDAJAX.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EmployeeDBContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("EmpDB")));
builder.Services.AddSingleton<IEmpRepository, EmpRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

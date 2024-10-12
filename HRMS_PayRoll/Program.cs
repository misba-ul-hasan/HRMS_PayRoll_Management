using HRMS_PayRoll.Handler.Services.Abstraction;
using HRMS_PayRoll.Handler.Services.Implementation;
using HRMS_PayRoll.Repository.Data;
using HRMS_PayRoll.Repository.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using HRMS_PayRoll.Repository.Repositories.Implementation;
using Rotativa.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
       option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
       m=>m.MigrationsAssembly("HRMS_PayRoll.Repository")));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IPayrollService),typeof(PayrollService));
builder.Services.AddScoped(typeof(IEmployeeService),typeof(EmployeeService));
RotativaConfiguration.Setup("wwwroot", "Rotativa");

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

app.Run();

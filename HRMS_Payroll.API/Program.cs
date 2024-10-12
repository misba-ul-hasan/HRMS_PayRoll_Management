using HRMS_PayRoll.Handler.Services.Abstraction;
using HRMS_PayRoll.Handler.Services.Implementation;
using HRMS_PayRoll.Repository.Data;
using HRMS_PayRoll.Repository.Repositories.Abstraction;
using HRMS_PayRoll.Repository.Repositories.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Rotativa.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
       option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
       m => m.MigrationsAssembly("HRMS_PayRoll.Repository")));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IPayrollService), typeof(PayrollService));
builder.Services.AddScoped(typeof(IEmployeeService), typeof(EmployeeService));
builder.Services.AddScoped(typeof(IAuthServiceHandler), typeof(AuthServiceHandler));
//RotativaConfiguration.Setup("wwwroot", "Rotativa");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(Option =>
{
    
}
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

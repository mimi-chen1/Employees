using Microsoft.EntityFrameworkCore;
using Practicom.API.Mapping;
using Practicom.API.MiddleWares;
using Practicom.Core;

using Practicom.Core.Repositories;
using Practicom.Core.Services;
using Practicom.Data;
using Practicom.Data.Repositories;
using Practicom.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmpolyeeRepository>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<IEmployeePositionService, EmployeePositionService>();
builder.Services.AddScoped<IEmployeePositionRepository, EmployeePositionRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(ApiMappingProfile));
builder.Services.AddDbContext<EmployeeContex>();
//builder.Services.AddDbContext<EmployeeContex>(
//    options => options.UseSqlServer(@"Server=DESKTOP-SI8MC0H;Database=Employees;Integrated Security=True;TrustServerCertificate=true"));
var policy = "policy";
builder.Services.AddCors(options =>
{
 options.AddPolicy(name:
policy, policy =>
{
  policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
 });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(policy);

//app.UseMiddleware<MiddleWare>();
app.MapControllers();

app.Run();

using Example.Application.CityService.Service;
using Example.Application.ExampleService.Service;
using Example.Application.PersonService.Service;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddDbContext<ExampleContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ExampleContext>();
    dataContext.Database.Migrate();
}

app.UseAuthorization();

app.MapControllers();

app.Run();


using System.Reflection;
using Application.CQRS.ProductCommandQuery.Command;
using Application.Interfaces;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;
using MediatR;

using Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Add services to the container.
builder.Services.AddControllers();

// 👇 اضافه کردن Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



string connectionString = builder.Configuration.GetConnectionString("sqlCnn");

builder.Services.AddDbContext<OnlineShopDbContext>(options =>
{ 
    options.UseSqlServer(connectionString);
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<SaveProductCommandHandler>();
});

builder.Services.AddRepository();
builder.Services.AddUnitOfWork();

builder.Services.AddScoped<IProductService, ProductService>();

// var config = new AutoMapper.MapperConfiguration(cfg =>
// {
//     cfg.AddProfile(new Application.AutoMapperConfig());
// });
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //app.MapScalarApiReference();
     app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

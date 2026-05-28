using CRUD.Data;
using CRUD.Repository;
using CRUD.Service;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
// Ensure this namespace is included for UseNLog extension method

var builder = WebApplication.CreateBuilder(args);

// ? Logging
var logger = LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();
builder.Logging.ClearProviders();
builder.Host.UseNLog(); // This requires the NLog.Web.AspNetCore package to be installed

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Defaultconnection"));
});

builder.Services.AddScoped<ICRUDRepository, CRUDRepository>();
builder.Services.AddScoped<ICRUDService, CRUDService>();

logger.Info("===== Server Started =====");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


using CompanyManagement.Configuration;
using CompanyManagement.Data;
using CompanyManagement.Extensions;
using CompanyManagement.Middleware;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;

Log.Logger = new LoggerConfiguration()
	.WriteTo.Console()
	.CreateLogger(); 

builder.Configuration.SetBasePath(env.ContentRootPath)
	.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
	.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

// Configuration
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection(nameof(ConnectionStrings)));

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.AddControllers();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLogger();

// SQL SERVER 
builder.Services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Enteprise")));

// Add Global Exception Handler 
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseExceptionHandler(opt => { });

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

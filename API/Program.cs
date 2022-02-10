using System.Net;
using API.Helpers;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var port = Environment.GetEnvironmentVariable("PORT") ?? "3000";

builder.WebHost.UseKestrel()
        .ConfigureKestrel((context, options) =>
        {
          options.Listen(IPAddress.Any, Int32.Parse(port), listenOptions =>
          {

          });
        });

Console.Write($"Heroku Port {port}");

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPlaceRepository, PlaceRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddCors();

var app = builder.Build();

//New Migration execute appp
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;
  var loggerFactory = services.GetRequiredService<ILoggerFactory>();
  try
  {
    var context = services.GetRequiredService<ApplicationDbContext>();
    await context.Database.MigrateAsync();
    await SeedDataBase.SeedAsync(context, loggerFactory);
  }
  catch (System.Exception ex)
  {
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "Migrations Failed");
  }
}

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//   app.UseSwagger();
//   app.UseSwaggerUI();
// }

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();

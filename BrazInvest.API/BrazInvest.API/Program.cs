using Infrastructure.Db.Data.Context;
using Infrastructure.Db.Repository.Data;
using Infrastructure.Db.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Services.Data;
using Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Validating and receiving the connection string
string mySqlConnection =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new Exception("A connection string was not configured correctly");

builder.Services.AddDbContext<BrazInvestDbContext>(options =>
                    options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddControllers();

//Add UseCase
builder.Services.AddScoped<IUserService, UserService>();

//addRepository
builder.Services.AddScoped<IUserRepository, UserRepository>();



//builder.Services.AddDbContext<BrazInvestDbContext>(options =>
//   options.UseMySql(mySqlConnection, new MySqlServerVersion(new Version("8.0.0"))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
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
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapControllers();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

using Microsoft.EntityFrameworkCore;
using QuizApi.Data;
using QuizApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injections
builder.Services.AddDbContext<QuizDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("quiz")));

builder.Services.AddCors((setup) => { setup.AddPolicy("default", (options) =>
    {
      options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});

var questions = new List<Question>
{
    new Question
    {
        Id = 1,
        Text = "What is the capital of France?",
        CorrectOptionId = 1,
        Options = new List<Option>
        {
            new Option { Id = 1, Text = "Paris", QuestionId = 1 },
            new Option { Id = 2, Text = "London", QuestionId = 1 },
            new Option { Id = 3, Text = "Berlin", QuestionId = 1 },
            new Option { Id = 4, Text = "Madrid", QuestionId = 1 },
        }
    },
    // Add more questions here
};


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
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

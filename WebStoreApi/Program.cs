
var builder = WebApplication.CreateBuilder(args);

//reading variables from appsettings.json

var lang = builder.Configuration["Language"];
var key = builder.Configuration["SecretKey"];
var log = builder.Configuration["Logging:LogLevel:Default"];

Console.WriteLine($"lang is {lang}, key is {key}, log is {log}");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
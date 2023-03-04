using ef_project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<TasksContext>("Data Source=DESKTOP-NMVIEF5\\SQLEXPRESS;Initial Catalog=TasksDB;user id=DanielBatres;password=0123456789");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconnection", async ([FromServices] TasksContext dbContext) => {
  dbContext.Database.EnsureCreated();
  return Results.Ok($"Database in memory: {dbContext.Database.IsInMemory()}");
});

app.Run();

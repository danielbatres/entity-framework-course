using ef_project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<TasksContext>(builder.Configuration.GetConnectionString("cnTasks"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconnection", async ([FromServices] TasksContext dbContext) => {
  dbContext.Database.EnsureCreated();
  return Results.Ok($"Database in memory: {dbContext.Database.IsInMemory()}");
});

app.MapGet("/api/tasks", async ([FromServices] TasksContext dbContext) => {
  return Results.Ok(dbContext.Tasks.Include(t => t.Category).Where(t => t.TaskPriority == ef_project.Models.Priority.Low));
});

app.Run();

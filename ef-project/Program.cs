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
  return Results.Ok(dbContext.Tasks.Include(t => t.Category));
});

app.MapPost("/api/tasks", async ([FromServices] TasksContext dbContext, [FromBody] ef_project.Models.Task task) =>
{
  task.TaskId = Guid.NewGuid();
  task.CreationDateTime = DateTime.Now;
  await dbContext.AddAsync(task);
  // await dbContext.Tasks.AddAsync(task);

  await dbContext.SaveChangesAsync();

  return Results.Ok();
});

app.Run();

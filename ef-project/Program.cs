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

app.MapPut("/api/tasks/{id}", async ([FromServices] TasksContext dbContext, [FromBody] ef_project.Models.Task task, [FromRoute] Guid id) =>
{
  var actualTask = dbContext.Tasks.Find(id);

  if (actualTask != null) {
    actualTask.CategoryId = task.CategoryId;
    actualTask.Title = task.Title;
    actualTask.TaskPriority = task.TaskPriority;
    actualTask.Description = task.Description;

    await dbContext.SaveChangesAsync();

    return Results.Ok();
  }

  return Results.NotFound();
});

app.MapDelete("/api/tasks/{id}", async ([FromServices] TasksContext dbContext, [FromRoute] Guid id) => {
  var actualTask = dbContext.Tasks.Find(id);

  if (actualTask != null) {
    dbContext.Remove(actualTask);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
  }

  return Results.NotFound();
});

app.Run();

using ef_project.Models;
using Microsoft.EntityFrameworkCore;

namespace ef_project;

public class TasksContext : DbContext {
  public DbSet<Category> Categories { get; set; }
  public DbSet<Task> Tasks { get; set; }

  public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }
}
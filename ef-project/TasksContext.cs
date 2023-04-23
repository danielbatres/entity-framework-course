using ef_project.Models;
using Microsoft.EntityFrameworkCore;
using Task = ef_project.Models.Task;

namespace ef_project;

public class TasksContext : DbContext {
  public DbSet<Category> Categories { get; set; }
  public DbSet<Task> Tasks { get; set; }

  public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.Entity<Category>(category => {
      category.ToTable("Category");
      category.HasKey(key => key.CategoryId);
      category.Property(p => p.Name).IsRequired().HasMaxLength(150);
      category.Property(p => p.Description);
    });
  }
}
using ef_project.Models;
using Microsoft.EntityFrameworkCore;
using Task = ef_project.Models.Task;

namespace ef_project;

public class TasksContext : DbContext {
  public DbSet<Category> Categories { get; set; }
  public DbSet<Task> Tasks { get; set; }

  public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    List<Category> CategoriesInit = new List<Category>();

    CategoriesInit.Add(new Category() {
      CategoryId = Guid.Parse("824d3c0a-900f-4069-a80f-ade59940e020"),
      Name = "Pending activities",
      Weight = 20
    });

    CategoriesInit.Add(new Category()
    {
      CategoryId = Guid.Parse("824d3c0a-900f-4069-a80f-ade59940e022"),
      Name = "Personal activities",
      Weight = 50
    });
    
    modelBuilder.Entity<Category>(category => {
      category.ToTable("Category");
      category.HasKey(p => p.CategoryId);
      category.Property(p => p.Name).IsRequired().HasMaxLength(150);
      category.Property(p => p.Description).IsRequired(false);
      category.Property(p => p.Weight);
      category.HasData(CategoriesInit);
    });

    List<Task> TaskInit = new List<Task>();

    TaskInit.Add(new Task() {
      TaskId = Guid.Parse("4da3fc64-ee46-4654-9387-f2ea2fe4116b"),
      CategoryId = Guid.Parse("824d3c0a-900f-4069-a80f-ade59940e020"),
      TaskPriority = Priority.Mid,
      Title = "Payment of public services",
      CreationDateTime = DateTime.Now
    });

    TaskInit.Add(new Task()
    {
      TaskId = Guid.Parse("0bf7dc7e-930c-45b4-b957-d9b6e9f5a175"),
      CategoryId = Guid.Parse("824d3c0a-900f-4069-a80f-ade59940e022"),
      TaskPriority = Priority.Low,
      Title = "Finish watching movie on netflix",
      CreationDateTime = DateTime.Now
    });

    modelBuilder.Entity<Task>(task => {
      task.ToTable("Task");
      task.HasKey(p => p.TaskId);
      task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
      task.Property(p => p.Title).IsRequired().HasMaxLength(200);
      task.Property(p => p.Description).IsRequired(false);
      task.Property(p => p.TaskPriority);
      task.Property(p => p.CreationDateTime);
      task.Ignore(p => p.Summary);
      task.HasData(TaskInit);
    });
  }
}
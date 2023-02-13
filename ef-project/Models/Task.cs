namespace ef_project.Models;

public class Tasks {
  public Guid TaskId { get; set; }
  public Guid CategoryId { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public Priority TaskPriority { get; set; }
  public DateTime CreationDateTime { get; set; }
  public virtual Category Category { get; set; }
}

public enum Priority {
  Low,
  Mid,
  High
}
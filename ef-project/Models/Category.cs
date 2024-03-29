using System.ComponentModel.DataAnnotations;

namespace ef_project.Models;

public class Category {
  //[Key]
  public Guid CategoryId { get; set; }
  //[Required]
  //[MaxLength(150)]
  public string Name { get; set; }
  public string Description { get; set; }
  public int Weight { get; set; }
  [System.Text.Json.Serialization.JsonIgnore]
  public virtual ICollection<Task> Tasks { get; set; }
}
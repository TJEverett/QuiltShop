using System.Collections.Generic;

namespace QuiltShop.Models
{
  public class Project
  {
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<ProjectStudent> Students { get; set; }
    public virtual ICollection<InstructorProject> Instructors { get; set; }

    public Project()
    {
      this.Students = new HashSet<ProjectStudent>();
      this.Instructors = new HashSet<InstructorProject>();
    }
  }
}
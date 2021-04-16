using System.Collections.Generic;

namespace QuiltShop.Models
{
  public class Instructor
  {
    public int InstructorId { get; set; }
    public string NameFirst { get; set; }
    public string NameLast { get; set; }
    public virtual ICollection<InstructorProject> Projects { get; set; }

    public Instructor()
    {
      this.Projects = new HashSet<InstructorProject>();
    }
  }
}
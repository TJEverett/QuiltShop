using System.Collections.Generic;

namespace QuiltShop.Models
{
  public class Student
  {
    public int StudentId { get; set; }
    public string NameFirst { get; set; }
    public string NameLast { get; set; }
    public virtual ICollection<ProjectStudent> Projects { get; set; }

    public Student()
    {
      this.Projects = new HashSet<ProjectStudent>();
    }
  }
}
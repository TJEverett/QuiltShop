namespace QuiltShop.Models
{
  public class ProjectStudent
  {
    public int ProjectStudentId { get; set; }
    public int StudentId { get; set; }
    public int ProjectId { get; set; }
    public virtual Student Student { get; set; }
    public virtual Project Project { get; set; }
  }
}
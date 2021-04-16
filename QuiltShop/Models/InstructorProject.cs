namespace QuiltShop.Models
{
  public class InstructorProject
  {
    public int InstructorProjectId { get; set; }
    public int ProjectId { get; set; }
    public int InstructorId { get; set; }
    public virtual Project Project { get; set; }
    public virtual Instructor Instructor { get; set; }
  }
}
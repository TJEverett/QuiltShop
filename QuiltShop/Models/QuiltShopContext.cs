using Microsoft.EntityFrameworkCore;

namespace QuiltShop.Models
{
  public class QuiltShopContext : DbContext
  {
    public virtual DbSet<Instructor> Instructors { get; set; }
    public virtual DbSet<Project> Projects { get; set; }
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<InstructorProject> InstructorProject { get; set; }
    public virtual DbSet<ProjectStudent> ProjectStudent { get; set; }

    public QuiltShopContext(DbContextOptions options) : base(options) { }
  }
}
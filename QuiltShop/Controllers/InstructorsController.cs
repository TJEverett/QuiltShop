using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using QuiltShop.Models;

namespace QuiltShop.Controllers
{
  public class InstructorsController : Controller
  {
    private readonly QuiltShopContext _db;

    public InstructorsController(QuiltShopContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Instructors.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Instructor instructor)
    {
      _db.Instructors.Add(instructor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Instructor thisInstructor = _db.Instructors
        .Include(instructor => instructor.Projects)
          .ThenInclude(join => join.Project)
        .FirstOrDefault(instructor => instructor.InstructorId == id);
      return View(thisInstructor);
    }

    public ActionResult Edit(int id)
    {
      Instructor thisInstructor = _db.Instructors.FirstOrDefault(instructor => instructor.InstructorId == id);
      return View(thisInstructor);
    }

    [HttpPost]
    public ActionResult Edit(Instructor instructor)
    {
      _db.Entry(instructor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Instructor thisInstructor = _db.Instructors.FirstOrDefault(instructor => instructor.InstructorId == id);
      return View(thisInstructor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Instructor thisInstructor = _db.Instructors.FirstOrDefault(instructor => instructor.InstructorId == id);
      _db.Instructors.Remove(thisInstructor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddProject(int id)
    {
      Instructor thisInstructor = _db.Instructors.FirstOrDefault(instructor => instructor.InstructorId == id);
      IEnumerable<SelectListItem> IdList = _db.Projects.Select(s => new SelectListItem
      {
        Value = s.ProjectId.ToString(),
        Text = $"{s.Name}"
      });
      ViewBag.ProjectId = IdList;
      return View(thisInstructor);
    }

    [HttpPost]
    public ActionResult AddProject(Instructor instructor, int ProjectId)
    {
      bool unique = true;
      List<InstructorProject> projectList = _db.Instructors
        .Where(i => i.InstructorId == instructor.InstructorId)
        .Select(i => i.Projects).ToList()[0].ToList();
      foreach(InstructorProject instructorProject in projectList)
      {
        if(instructorProject.ProjectId == ProjectId)
        {
          unique = false;
        }
      }
      if(ProjectId != 0 && unique)
      {
        _db.InstructorProject.Add(new InstructorProject() {ProjectId = ProjectId, InstructorId = instructor.InstructorId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteProject(int joinId)
    {
      InstructorProject joinEntry = _db.InstructorProject.FirstOrDefault(entry => entry.InstructorProjectId == joinId);
      _db.InstructorProject.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
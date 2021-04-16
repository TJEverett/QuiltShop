using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using QuiltShop.Models;

namespace QuiltShop.Controllers
{
  public class StudentsController : Controller
  {
    private readonly QuiltShopContext _db;

    public StudentsController(QuiltShopContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Students.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Student student)
    {
      _db.Add(student);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Student thisStudent = _db.Students
        .Include(student => student.Projects)
          .ThenInclude(join => join.Project)
        .FirstOrDefault(student => student.StudentId == id);
      return View(thisStudent);
    }

    public ActionResult Edit(int id)
    {
      Student thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
      return View(thisStudent);
    }

    [HttpPost]
    public ActionResult Edit(Student student)
    {
      _db.Entry(student).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Student thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
      return View(thisStudent);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Student thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
      _db.Students.Remove(thisStudent);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddProject(int id)
    {
      Student thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
      IEnumerable<SelectListItem> IdList = _db.Projects.Select(s => new SelectListItem
      {
        Value = s.ProjectId.ToString(),
        Text = $"{s.Name}"
      });
      ViewBag.ProjectId = IdList;
      return View(thisStudent);
    }

    [HttpPost]
    public ActionResult AddProject(Student student, int ProjectId)
    {
      bool unique = true;
      List<ProjectStudent> projectList = _db.Students
        .Where(i => i.StudentId == student.StudentId)
        .Select(i => i.Projects).ToList()[0].ToList();
      foreach(ProjectStudent projectStudent in projectList)
      {
        if(projectStudent.ProjectId == ProjectId)
        {
          unique = false;
        }
      }
      if(ProjectId != 0 && unique)
      {
        _db.ProjectStudent.Add(new ProjectStudent() {ProjectId = ProjectId, StudentId = student.StudentId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteProject(int joinId)
    {
      ProjectStudent joinEntry = _db.ProjectStudent.FirstOrDefault(entry => entry.ProjectStudentId == joinId);
      _db.ProjectStudent.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using QuiltShop.Models;

namespace QuiltShop.Controllers
{
  public class ProjectsController : Controller
  {
    private readonly QuiltShopContext _db;

    public ProjectsController(QuiltShopContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Projects.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Project project)
    {
      _db.Add(project);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Project thisProject = _db.Projects
        .Include(project => project.Instructors)
          .ThenInclude(join => join.Instructor)
        .Include(project => project.Students)
          .ThenInclude(join => join.Student)
        .FirstOrDefault(project => project.ProjectId == id);
      return View(thisProject);
    }

    public ActionResult Edit(int id)
    {
      Project thisProject = _db.Projects.FirstOrDefault(project => project.ProjectId == id);
      return View(thisProject);
    }

    [HttpPost]
    public ActionResult Edit(Project project)
    {
      _db.Entry(project).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Project thisProject = _db.Projects.FirstOrDefault(project => project.ProjectId == id);
      return View(thisProject);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfrimed(int id)
    {
      Project thisProject = _db.Projects.FirstOrDefault(project => project.ProjectId == id);
      _db.Projects.Remove(thisProject);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
using Microsoft.AspNetCore.Mvc;

namespace QuiltShop.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}
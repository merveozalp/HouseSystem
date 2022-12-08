using Microsoft.AspNetCore.Mvc;

namespace BuildingSystem.UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

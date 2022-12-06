using Microsoft.AspNetCore.Mvc;

namespace BuildingSystem.UI.Controllers
{
    public class BuildingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

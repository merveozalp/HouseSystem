using Entites.Entitiy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BuildingSystem.UI.Controllers
{
    //[Authorize(Roles = "Yönetici")]
    public class OccupantController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public OccupantController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            User user = _userManager.FindByNameAsync(User.Identity.Name).Result;


            return View();
        }
    }
}

using BuildingSystem.Entities.Dtos;
using Entites.Entitiy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BuildingSystem.UI.Controllers
{
    public class AdminController : Controller
    {


        private UserManager<User> _userManager { get; }

        public AdminController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        // Kullanıcıları getiriyorum. Bunlar Async metotlar 
        public  IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }
    }
}

using BuildingSystem.Business.Abstract;
using BuildingSystem.Entities.Dtos;
using Entites.Entitiy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BuildingSystem.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public UserController(IUserService userService, UserManager<User> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult AddUser()
            {
                return View();
            }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDto userDto)
        {
            User user = new User()
            {
                IdentityNo = userDto.IdentityNo,
                UserName = userDto.UserName,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                CarNo = userDto.CarNo,
                PhoneNumber = userDto.PhoneNumber,

            };
            IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("GetAllUsers");
            }
            return View(userDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
             var result = await _userService.GetAllAsync();
             return View(result);
        }

        [HttpGet]
        public IActionResult DeleteUser(string id)
        {
            _userService.Delete(id);
            return RedirectToAction("GetAllUsers");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(string id)
        {
            var user = await _userService.FindById(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserDto userDto)
        {
           if (!ModelState.IsValid) return View(userDto);
           await _userService.UpdateUserAsync(userDto);
           return RedirectToAction("GetAllUsers");
        }
        
    }
}

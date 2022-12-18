using BuildingSystem.Business.Abstract;
using BuildingSystem.Entities.Dtos;
using BuildingSystem.UI.Filters;
using Entites.Entitiy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingSystem.UI.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IExpenseService expenseService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public HomeController(ILogger<HomeController> logger, IUserService userService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _logger = logger;
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LogIn(model);
                foreach (var item in result.ToList())
                {
                    if (item.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (item.Contains("Yönetici"))
                    {
                        return RedirectToAction("Inbox", "Occupant");
                    }
                }
            }

            else
            {
                ModelState.AddModelError("", "Geçersiz kullanıcı adi veya şifresi");
            }

            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserDto dto)
        {
            
            var result = await _userService.UserRegister(dto);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View(dto);
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}

using BuildingSystem.Business.Abstract;
using BuildingSystem.Entities.Dtos;
using BuildingSystem.UI.Models;
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
        public IActionResult LogIn(string returnUrl)
        {
            TempData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LogIn(loginDto);
                if (result.Succeeded)
                {
                    User user = await _userManager.FindByEmailAsync(loginDto.Email);
                    IList<string> roles = await _userManager.GetRolesAsync(user);
                    foreach (var item in roles)
                    {
                        if (item.Contains("Admin"))
                        {
                           
                            return RedirectToAction("GetAllBuilding", "Building");
                        }
                        else if (item.Contains("Yönetici"))
                        {
                            
                            return RedirectToAction("GetAllExpense", "Expense");
                        }
                    }
                    return RedirectToAction("GetAllBuilding", "Building");
                }
                else
                {
                    ModelState.AddModelError("", "Geçersiz kullanıcı adi veya şifresi");
                }
            }
            return View(loginDto);
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
            User user = new User()
            {
                IdentityNo = dto.IdentityNo,
                UserName = dto.UserName,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                CarNo = dto.CarNo,
                PhoneNumber = dto.PhoneNumber,

            };
            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);
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

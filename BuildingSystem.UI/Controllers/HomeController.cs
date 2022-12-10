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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public HomeController(ILogger<HomeController> logger, IUserService userService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _logger = logger;
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult LogIn(string ReturnUrl = null)
        {
            return View(new LoginDto()
            {
                ReturnUrl = ReturnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginDto loginDto)
        {
            if (!ModelState.IsValid) return View(loginDto);
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return View(loginDto);
            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, false);
            if (result.Succeeded) return Redirect(loginDto.ReturnUrl ?? "~/");
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

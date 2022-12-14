using BuildingSystem.Business.Abstract;
using BuildingSystem.Entities.Dtos;
using Entites.Entitiy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingSystem.UI.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<User> _userManager { get; }
        private RoleManager<Role> _roleManager { get; }
        private IRoleService _roleService { get; }
        public AdminController(UserManager<User> userManager, RoleManager<Role> roleManager, IRoleService roleService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _roleService = roleService;
        }
        // Kullanıcıları getiriyorum. Bunlar Async metotlar 
        public  IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }
        public IActionResult GetAllRole()
        {
           var roleList = _roleService.GetAllRole();
            return View(roleList);
        }
        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(string roleName)
        {
          
            await _roleService.CreateRole(roleName);
            return RedirectToAction("GetAllRole");
        }
        public IActionResult RoleAssign(string id)
        {
            User user = _userManager.FindByIdAsync(id).Result;
            TempData["userId"] = id;
            ViewBag.UserName = user.UserName;
            IQueryable<Role> roles = _roleManager.Roles;
            List<string> userRole =_userManager.GetRolesAsync(user).Result as List<string>;

            List<RoleAssignDto> roleAssignDtos = new List<RoleAssignDto>();
            foreach (var item in roles)
            {
                RoleAssignDto dtos = new RoleAssignDto();

                dtos.RoleId = item.Id;
                dtos.RoleName = item.Name;

                if (userRole.Contains(item.Name))
                {
                    dtos.Exist= true;
                }
                else
                {
                    dtos.Exist = false;

                }
              
            roleAssignDtos.Add(dtos);
            }
            return View(roleAssignDtos);
        }
        [HttpPost]
        public async Task<IActionResult> RoleAssign(List<RoleAssignDto> roleAssignDtos)
        {

            User user = await _userManager.FindByIdAsync(TempData["userId"].ToString());
            foreach (var item in roleAssignDtos)
            {
                if (item.Exist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName); // Rol Atama İşlemi 
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName); //Rol silme işlemi
                }
              
            }
            return RedirectToAction("GetAllUsers","User");
        }
    }
}

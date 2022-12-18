using BuildingSystem.Business.Abstract;
using BuildingSystem.Entities.Dtos;
using Entites.Entitiy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingSystem.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private UserManager<User> _userManager { get; }
        private RoleManager<Role> _roleManager { get; }
        private IRoleService _roleService { get; }
        private readonly IBuildingService _buildingService;
        private readonly IExpenseService _expenseService;
        private readonly IExpenseTypeService _expenseTypeService;
        private readonly IFlatService _flatService;
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;
        public AdminController(UserManager<User> userManager, RoleManager<Role> roleManager, IRoleService roleService, IBuildingService buildingService, IExpenseService expenseService, IExpenseTypeService expenseTypeService, IFlatService flatService, IUserService userService, IMessageService messageService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _roleService = roleService;
            _buildingService = buildingService;
            _expenseService = expenseService;
            _expenseTypeService = expenseTypeService;
            _flatService = flatService;
            _userService = userService;
            _messageService = messageService;
        }

        #region About Role
        // Kullanıcıları getiriyorum. Bunlar Async metotlar 
        public IActionResult Index()
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
            if (ModelState.IsValid)
            {
                await _roleService.CreateRole(roleName);
                return RedirectToAction("GetAllRole");
            }
            return View(roleName);
        }
        [HttpGet]
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
            return RedirectToAction("GetAllUsers");
        }
        public async Task<IActionResult> RoleDelete(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleService.Delete(id);
                return RedirectToAction("GetAllRole");
            }

            return View();
        }
        #endregion

        #region About user
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddAsync(userDto);
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

        #endregion

     

        //#region About Flat
        //[HttpGet]
        //public async Task<ActionResult> GetAllFlat()
        //{
        //    var flats = await _flatService.GetAllFlatsWithRelation();
        //    return View(flats);
        //}

        //[HttpGet]
        //public async Task<IActionResult> AddFlat()
        //{
        //    var buildingDto = await _buildingService.GetAllAsync();
        //    ViewBag.Building = new SelectList(buildingDto, "Id", "BuildingName");
        //    var userDto = await _userService.GetAllAsync();
        //    ViewBag.User = new SelectList(userDto, "Id", "UserName");
           
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddFlat(FlatCreateDto flatCreateDto)
        //{
        //    if(!ModelState.IsValid)
        //    {
        //        var buildingDto = await _buildingService.GetAllAsync();
        //        ViewBag.Building = new SelectList(buildingDto, "Id", "BuildingName");
        //        var userDto = await _userService.GetAllAsync();
        //        ViewBag.User = new SelectList(userDto, "Id", "UserName");
        //        return View(flatCreateDto);
        //    }

        //    flatCreateDto.IsEmpty = true;
        //    await _flatService.AddAsync(flatCreateDto);
        //    return RedirectToAction("GetAllFlat");
        //}
        //[HttpGet]
        //public async Task<IActionResult> UpdateFlat(int id)
        //{
        //    var flat = await _flatService.GetById(id);
        //    var flats = await _flatService.GetAllAsync();
        //    var buildingDto = await _buildingService.GetAllAsync();
        //    ViewBag.Building = new SelectList(buildingDto, "Id", "BuildingName");
        //    var userDto = await _userService.GetAllAsync();
        //    ViewBag.User = new SelectList(userDto, "Id", "UserName");

        //    var flatUpdateDto = new FlatUpdateDto()
        //    {
        //        Id = flat.Id,
        //        FloorNumber = flat.FloorNumber,
        //        IsOwner = flat.IsOwner,
        //        IsEmpty = flat.IsEmpty,
        //        FlatType = flat.FlatType,
        //        FlatNumber=flat.FlatNumber,
                
                
               
        //    };
        //    return View(flatUpdateDto);
        //}
        //[HttpPost]
        //public async Task<IActionResult> UpdateFlat(FlatUpdateDto flatUpdateDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var buildingDto = await _buildingService.GetAllAsync();
        //        ViewBag.Building = new SelectList(buildingDto, "Id", "BuildingName");
        //        var userDto = await _userService.GetAllAsync();
        //        ViewBag.User = new SelectList(userDto, "Id", "UserName");
        //        return View(flatUpdateDto);
        //    }
        //    _flatService.UpdateAsync(flatUpdateDto);
        //    return RedirectToAction("GetAllFlat");
        //}
        //[HttpGet]
        //public IActionResult DeleteFlat(int id)
        //{

        //    _flatService.DeleteAsync(id);
        //    return RedirectToAction("GetAllFlat");
        //}
        //#endregion

      

    }
}

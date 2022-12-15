using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.Concrete;
using BuildingSystem.Entities.Dtos;
using Entites.Entitiy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingSystem.UI.Controllers
{
    //[Authorize(Roles="Admin")]
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

        #region About User
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
        #endregion

        #region About Building
        public async Task<IActionResult> GetAllBuilding()
        {
            var buildings = await _buildingService.GetAllAsync();
            return View(buildings);
        }
        [HttpGet]
        public IActionResult AddBuilding()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBuilding(BuildingDto buildingDto)
        {
            if (ModelState.IsValid)
            {
                var buildings = await _buildingService.AddAsync(buildingDto);
                return RedirectToAction("GetAllBuilding");
            }

            return View();

        }
        [HttpGet]
        public async Task<IActionResult> UpdateBuilding(int id)
        {
            var building = await _buildingService.GetById(id);
            if (building == null) return RedirectToAction("GetAllBuilding");
            return View(building);
        }
        [HttpPost]
        public IActionResult UpdateBuilding(BuildingDto buildingDto)
        {
            _buildingService.Update(buildingDto);
            return RedirectToAction("GetAllBuilding");
        }
        [HttpGet]
        public IActionResult DeleteBuilding(int id)
        {
            _buildingService.Delete(id);
            return RedirectToAction("GetAllBuilding");
        }
        #endregion

        #region About Expense
        [HttpGet]
        public async Task<IActionResult> AddExpense()
        {
            var expenseType = await _expenseTypeService.GetAllAsync();
            var flats = await _flatService.GetAllAsync();
            var createExpense = new ExpenseCreateDto()
            {
                ExpenseTypes = expenseType,
                Flats = flats
            };
            return View(createExpense);
        }
        [HttpPost]
        public async Task<IActionResult> AddExpense(ExpenseCreateDto expenseCreateDto)
        {
            if (!ModelState.IsValid) return View(expenseCreateDto);
            expenseCreateDto.InvoiceDate = DateTime.Now;
            expenseCreateDto.IsPaid = false;
            var expenses = await _expenseService.AddAsync(expenseCreateDto);
            return RedirectToAction("GetAllExpenses");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateExpense(int id)
        {
            var expenses = await _expenseService.GetById(id);
            var expenseTypes = await _expenseTypeService.GetAllAsync();
            var flats = await _flatService.GetAllAsync();
            var buildings = await _buildingService.GetAllAsync();
            var expenseDto = new ExpenseUpdateDto()
            {
                Id = expenses.Id,
                IsPaid = expenses.IsPaid,
                InvoiceDate = DateTime.Now,
                Cost = expenses.Cost,
                ExpenseTypes = expenseTypes,
                Flats = flats,
                Buildings = buildings

            };
            return View(expenseDto);
        }
        [HttpPost]
        public IActionResult UpdateExpense(ExpenseUpdateDto updateExpenseDto)
        {
            if (!ModelState.IsValid) return View(updateExpenseDto);
            _expenseService.UpdateAsync(updateExpenseDto);
            return RedirectToAction("GetAllExpenses");

        }
        [HttpGet]
        public IActionResult DeleteExpense(int id)
        {
            _expenseService.DeleteAsync(id);
            return RedirectToAction("GetAllExpenses");
        }
        [HttpGet]
        public async Task<IActionResult> GetIsPaidExpense()
        {
            var expenses = await _expenseService.GetAllExpenses();
            var ısPaid = expenses.Where(x => x.IsPaid == true).ToList();
            return View(ısPaid);
        }
        [HttpGet]
        public async Task<IActionResult> GetUnPaidExpense()
        {
            var expenses = await _expenseService.GetAllExpenses();
            var unIsPaid = expenses.Where(x => x.IsPaid == false).ToList();
            return View(unIsPaid);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllExpenses()
        {
            var expenses = await _expenseService.GetAllExpenses();
            return View(expenses);
        }
        #endregion

        #region About ExpenseType
        [HttpGet]
        public async Task<IActionResult> GetAllExpenseType()
        {
            var expensesType = await _expenseTypeService.GetAllAsync();
            return View(expensesType);
        }
        [HttpGet]
        public IActionResult AddExpenseType()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddExpenseType(ExpenseTypeDto expenseTypeDto)
        {
            if (!ModelState.IsValid) return View(expenseTypeDto);
            await _expenseTypeService.AddAsync(expenseTypeDto);
            return RedirectToAction("GetAllExpenseType");
        }
        [HttpGet]
        public IActionResult DeleteExpenseType(int id)
        {

            _expenseTypeService.Delete(id);
            return RedirectToAction("GetAllExpenseType");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateExpenseType(int id)
        {
            var expensesType = await _expenseTypeService.GetById(id);
            if (expensesType is null) return RedirectToAction("GetAllExpenseType");
            return View(expensesType);

        }
        [HttpPost]
        public IActionResult UpdateExpenseType(ExpenseTypeDto expenseTypeDto)
        {
            _expenseTypeService.Update(expenseTypeDto);
            return RedirectToAction("GetAllExpenseType");

        }
        #endregion

        #region About Flat
        [HttpGet]
        public async Task<ActionResult> GetAllFlat()
        {
            var flats = await _flatService.GetAllFlatsWithRelation();
            return View(flats);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var flats = await _flatService.GetById(id);
            return View(flats);
        }
        [HttpGet]
        public async Task<IActionResult> AddFlat()
        {
            var buildingDto = await _buildingService.GetAllAsync();
            var userDto = await _userService.GetAllAsync();
            var flatAdd = new FlatCreateDto()
            {
                Buildings = buildingDto,
                Users = userDto

            };
            return View(flatAdd);
        }
        [HttpPost]
        public async Task<IActionResult> AddFlat(FlatCreateDto flatCreateDto)
        {
            if (ModelState.IsValid)
            {
                flatCreateDto.IsEmpty = true;
                await _flatService.AddAsync(flatCreateDto);
                return RedirectToAction("GetAll");
            }

            return View(flatCreateDto);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateFlat(int id)
        {
            var flat = await _flatService.GetById(id);
            var flats = await _flatService.GetAllAsync();
            var buildingDto = await _buildingService.GetAllAsync();
            var userDto = await _userService.GetAllAsync();

            var flatUpdateDto = new FlatUpdateDto()
            {
                Id = flat.Id,
                FloorNumber = flat.FloorNumber,
                IsOwner = flat.IsOwner,
                IsEmpty = flat.IsEmpty,
                FlatType = flat.FlatType,
                Buildings = buildingDto,
                Users = userDto
            };
            return View(flatUpdateDto);
        }
        [HttpPost]
        public IActionResult UpdateFlat(FlatUpdateDto flatUpdateDto)
        {
            if (!ModelState.IsValid) return View(flatUpdateDto);
            _flatService.UpdateAsync(flatUpdateDto);
            return RedirectToAction("GetAll");
        }
        [HttpGet]
        public IActionResult DeleteFlat(int id)
        {

            _flatService.DeleteAsync(id);
            return RedirectToAction("GetAll");
        }
        #endregion

        #region About Mesaage

        [HttpGet]
        public async Task<IActionResult> Inbox()
        {
            var user = _userService.GetUserFromSession();
            var allMessages = await _messageService.GetAllAsync();
            if (allMessages != null)
            {
                var messageList = allMessages.Where(m => m.ReceiverId == user.Id).ToList();
                var inboxList = await _messageService.GetListInbox(messageList);
                return View(inboxList.Data);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Outbox()
        {
            var user = _userService.GetUserFromSession();
            var allMessages = await _messageService.GetAllAsync();
            if (allMessages != null)
            {
                var messageList = allMessages.Where(m => m.SenderId == user.Id).ToList();
                var outBoxList = await _messageService.GetListOutbox(messageList);
                return View(outBoxList.Data);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            var userList = await _userService.GetAllAsync();
            var messageDto = new MessageDto
            {
                Users = userList
            }
            return View(messageDto);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageDto message)
        {
            var user = _userService.GetUserFromSession();
            message.SenderMail = user.Id;
            await _messageService.AddAsync(message);
            return RedirectToAction("OutBox");
        }
        #endregion

    }
}

using BuildingSystem.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System;
using BuildingSystem.Business.Abstract;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace BuildingSystem.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IExpenseTypeService _expenseTypeService;
        private readonly IFlatService _flatService;
        private readonly IBuildingService _buildingService;
        public ExpenseController(IExpenseService expenseService, IExpenseTypeService expenseTypeService, IFlatService flatService, IBuildingService buildingService)
        {
            _expenseService = expenseService;
            _expenseTypeService = expenseTypeService;
            _flatService = flatService;
            _buildingService = buildingService;
        }

        [HttpGet]
        public async Task<IActionResult> AddExpense()
        {
            var expenseTypes = await _expenseTypeService.GetAllAsync();
            ViewBag.expenseType = new SelectList(expenseTypes, "Id", "ExpenseTypeName");

            var flats = await _flatService.GetAllAsync();
            ViewBag.flat = new SelectList(flats, "Id", "FlatNumber");

            var buildings = await _buildingService.GetAllAsync();
            ViewBag.building = new SelectList(buildings, "Id", "BuildingName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddExpense(ExpenseCreateDto expenseCreateDto)
        {
            if (!ModelState.IsValid)
            {
                var expenseTypes = await _expenseTypeService.GetAllAsync();
                ViewBag.expenseType = new SelectList(expenseTypes, "Id", "ExpenseTypeName");

                var flats = await _flatService.GetAllAsync();
                ViewBag.flat = new SelectList(flats, "Id", "FlatNumber");

                var buildings = await _buildingService.GetAllAsync();
                ViewBag.building = new SelectList(buildings, "Id", "BuildingName");
                return View(expenseCreateDto);
            }
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
            ViewBag.expenseType = new SelectList(expenseTypes, "Id", "ExpenseTypeName");

            var flats = await _flatService.GetAllAsync();
            ViewBag.flat = new SelectList(flats, "Id", "FlatNumber");

            var buildings = await _buildingService.GetAllAsync();
            ViewBag.building = new SelectList(buildings, "Id", "BuildingName");

            var expenseDto = new ExpenseUpdateDto()
            {
                Id = expenses.Id,
                IsPaid = expenses.IsPaid,
                InvoiceDate = DateTime.Now,
                Cost = expenses.Cost,
            };
            return View(expenseDto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateExpense(ExpenseUpdateDto updateExpenseDto)
        {
            if (!ModelState.IsValid)
            {
                var expenseTypes = await _expenseTypeService.GetAllAsync();
                ViewBag.expenseType = new SelectList(expenseTypes, "Id", "ExpenseTypeName");

                var flats = await _flatService.GetAllAsync();
                ViewBag.flat = new SelectList(flats, "Id", "FlatNumber");

                var buildings = await _buildingService.GetAllAsync();
                ViewBag.building = new SelectList(buildings, "Id", "BuildingName");
                return View(updateExpenseDto);
            }
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
        

    }
}

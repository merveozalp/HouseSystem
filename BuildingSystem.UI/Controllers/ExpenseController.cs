using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.Concrete;
using BuildingSystem.Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingSystem.UI.Controllers
{
    //[Authorize(Roles = "Yönetici")]
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IFlatService _flatService;
        private readonly IExpenseTypeService _expenseTypeService;
        private readonly IBuildingService _buildingService;

        public ExpenseController(IExpenseService expenseService, IExpenseTypeService expenseTypeService, IFlatService flatService, IBuildingService buildingService)
        {
            _expenseService = expenseService;
            _expenseTypeService = expenseTypeService;
            _flatService = flatService;
            _buildingService = buildingService;
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var expenseType = await _expenseTypeService.GetAllAsync();
            var flats = await _flatService.GetAllAsync();
            var createExpense = new ExpenseCreateDto()
            {
                ExpenseTypes = expenseType,
                Flats = flats
            };
            return View (createExpense);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ExpenseCreateDto expenseCreateDto)
        {
            if (!ModelState.IsValid) return View(expenseCreateDto);
            expenseCreateDto.InvoiceDate = DateTime.Now;
            expenseCreateDto.IsPaid = false;
            var expenses = await _expenseService.AddAsync(expenseCreateDto);
            return RedirectToAction("GetAllExpenses");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
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
                Buildings=buildings
                
            };
            return View(expenseDto);
        }
        [HttpPost]
        public IActionResult Update(ExpenseUpdateDto updateExpenseDto)
        {
            if (!ModelState.IsValid) return View(updateExpenseDto);
            _expenseService.UpdateAsync(updateExpenseDto);
            return RedirectToAction("GetAllExpenses");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _expenseService.DeleteAsync(id);
            return RedirectToAction("GetAllExpenses");
        }
        [HttpGet]
        public async Task<IActionResult> GetIsPaid()
        {
            var expenses = await _expenseService.GetAllExpenses();
            var ısPaid = expenses.Where(x => x.IsPaid == true).ToList();
            return View(ısPaid);
        }
        [HttpGet]
        public async Task<IActionResult> GetUnPaid()
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
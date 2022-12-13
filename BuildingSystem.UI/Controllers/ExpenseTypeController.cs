using BuildingSystem.Business.Abstract;
using BuildingSystem.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace BuildingSystem.UI.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly IExpenseTypeService _expenseTypeService;

        public ExpenseTypeController(IExpenseTypeService expenseTypeService)
        {
            _expenseTypeService = expenseTypeService;
        }

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
        public async Task<IActionResult> AddExpenseType (ExpenseTypeDto expenseTypeDto)
        {
            if (!ModelState.IsValid) return View(expenseTypeDto);
            await _expenseTypeService.AddAsync(expenseTypeDto);
            return RedirectToAction("GetAllExpenseType");
        }

        [HttpGet]
        public IActionResult Delete (int id)
        {
           
            _expenseTypeService.Delete(id);
            return RedirectToAction("GetAllExpenseType");
        }
        [HttpGet]
        public async  Task<IActionResult> UpdateExpenseType(int id)
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
    }
}

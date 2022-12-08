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
        public async Task<IActionResult> GetAll()
        {
            var expensesType = await _expenseTypeService.GetAllAsync();
            return View(expensesType);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add (ExpenseTypeDto expenseTypeDto)
        {
            if (!ModelState.IsValid) return View(expenseTypeDto);
            await _expenseTypeService.AddAsync(expenseTypeDto);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Delete (int id)
        {
           
            await _expenseTypeService.DeleteAsync(id);
            return RedirectToAction("GetAll");
        }
        [HttpGet]
        public async  Task<IActionResult> Update(int id)
        {
            var expensesType = await _expenseTypeService.GetById(id);
            if (expensesType is null) return RedirectToAction("GetAll");
            return View(expensesType);
            
        }

        [HttpPost]
        public IActionResult Update(ExpenseTypeDto expenseTypeDto)
        {
            _expenseTypeService.UpdateAsync(expenseTypeDto);
            return RedirectToAction("GetAll");

        }
    }
}

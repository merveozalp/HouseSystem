using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.Concrete;
using BuildingSystem.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingSystem.UI.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IFlatService _flatService;
        private readonly IExpenseTypeService _expenseTypeService;

        public ExpenseController(IExpenseService expenseService, IExpenseTypeService expenseTypeService, IFlatService flatService)
        {
            _expenseService = expenseService;
            _expenseTypeService = expenseTypeService;
            _flatService = flatService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var expenses = await _expenseService.GetAllAsync();
            return View(expenses);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var expenses = await _expenseService.GetById(id);
            return View(expenses);
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
            if (ModelState.IsValid)
            {
                expenseCreateDto.IsPaid = true;
                var expenses = await _expenseService.AddAsync(expenseCreateDto);
                return RedirectToAction("GetAllExpenses");
            }

           
            return View(expenseCreateDto);
          

        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var ExpenseType = await _expenseTypeService.GetAllAsync();
            ViewBag.ExpensesType = new SelectList(ExpenseType, "Id", "TypeName");
            var flats = await _flatService.GetAllAsync();
            ViewBag.Flat = new SelectList(flats, "Id", "FlatNumber");
            var expenses = await _expenseService.GetById(id);
            if (expenses is null) return RedirectToAction("GetAllExpenses");
            return View(expenses);
        }

        [HttpPost]
        public IActionResult Update(UpdateExpenseDto updateExpenseDto)
        {
            if (!ModelState.IsValid) return View(updateExpenseDto);
            _expenseService.UpdateAsync(updateExpenseDto);
            return RedirectToAction("GetAllExpenses");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
           
            await _expenseService.DeleteAsync(id);
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
        public async Task<IActionResult> GetUnIsPaid()
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
using BuildingSystem.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BuildingSystem.UI.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly IExpenseTypeService _expenseTypeService;

        public ExpenseTypeController(IExpenseTypeService expenseTypeService)
        {
            _expenseTypeService = expenseTypeService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

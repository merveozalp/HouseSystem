﻿using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.Concrete;
using BuildingSystem.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
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
            var expensesTypes = await _expenseService.GetAllAsync();
           // var flats = await _flatService.GetAllAsync();
           //var createExpenses = new ExpenseCreateDto
           //{
           //    //Flats= flats.Data
           //}
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Add(ExpenseCreateDto expenseCreateDto)
        {
            if (!ModelState.IsValid) return View(expenseCreateDto);
            expenseCreateDto.IsPaid = false;
            var expenses = await _expenseService.AddAsync(expenseCreateDto);
            return RedirectToAction("GetAll");
           
        }

        [HttpGet]
        public async Task<IActionResult> Update (int id)
        {
            var expenses = _expenseService.GetById(id);
            if (expenses is null) return RedirectToAction("GetAll");
            return View(expenses);
        }

        [HttpPost]
        public IActionResult Update(UpdateExpenseDto updateExpenseDto)
        {
            _expenseService.UpdateAsync(updateExpenseDto);
            return RedirectToAction("GetAll");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var expenses = await _expenseService.GetById(id);
            await _expenseService.DeleteAsync(expenses);
            return RedirectToAction("GetAll");
        }

    }
}
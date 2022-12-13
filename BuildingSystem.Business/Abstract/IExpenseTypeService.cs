using BuildingSystem.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Abstract
{
    public interface IExpenseTypeService
    {
        Task<ExpenseTypeDto> GetById(int id);
        Task<List<ExpenseTypeDto>> GetAllAsync();
        Task<ExpenseTypeDto> AddAsync(ExpenseTypeDto expenseTypeDto);
        void Update(ExpenseTypeDto expenseTypeDto);
        void Delete(int id);
    }
}

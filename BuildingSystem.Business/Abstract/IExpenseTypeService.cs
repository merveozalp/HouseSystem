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
        Task<IEnumerable<ExpenseTypeDto>> GetAllAsync();
        Task<ExpenseTypeDto> AddAsync(ExpenseTypeDto expenseTypeDto);
        Task UpdateAsync(ExpenseTypeDto expenseTypeDto);
        Task DeleteAsync(int id);
    }
}

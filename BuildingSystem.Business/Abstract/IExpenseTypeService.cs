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
        Task<ExpenseTypeDto> GetById(int Id);
        Task<IEnumerable<ExpenseTypeDto>> GetAllAsync();
        Task<ExpenseTypeDto> AddAsync(ExpenseTypeDto dto);
        Task UpdateAsync(ExpenseTypeDto dto);
        Task DeleteAsync(int id);
    }
}

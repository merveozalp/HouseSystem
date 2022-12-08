using BuildingSystem.Entities.Dtos;
using Entites.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Abstract
{
    public interface IExpenseService
    {
        Task<ExpenseDto> GetById(int Id);
        Task<IEnumerable<ExpenseDto>> GetAllAsync();
        Task<ExpenseCreateDto> AddAsync(ExpenseCreateDto dto);
        Task UpdateAsync(UpdateExpenseDto dto);
        Task DeleteAsync(int id);
        Task<List<ExpenseDto>> GetAllExpenses();
  
}
}

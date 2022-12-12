using BuildingSystem.Entities.Dtos;
using BuildingSystem.Entities.Entity;
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
        Task<ExpenseCreateDto> AddAsync(ExpenseCreateDto expenseCreateDto);
        Task UpdateAsync(ExpenseUpdateDto expenseCreateDto);
        Task DeleteAsync(int id);
        Task<List<ExpenseDto>> GetAllExpenses();

        void SendMail();

    }
}

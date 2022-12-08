using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.DataAccess.Context;
using Entites.Entitiy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.DataAccess.Concrete
{
    public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<List<Expense>> GetAllExpenses()
        {
           return await _db.Expenses.Include(x=>x.ExpenceType).Include(x=>x.Flat).ThenInclude(x=>x.User).ToListAsync();
        }
    }
}

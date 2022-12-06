using Entites.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Entities.Entity
{
    public class ExpenseType:Base
    {
        public ExpenseType()
        {
            Expenses = new HashSet<Expense>();
        }
        public string TypeName { get; set; }

        public ICollection<Expense> Expenses { get; set; }
    }
}

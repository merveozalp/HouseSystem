using BuildingSystem.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Entitiy
{
    public class Expense:Base
    {
        // Enum ile elektirk / doğalgaz/ su/aidat seçeneleri sunulması.
        public string Name { get; set; }
        public double Cost { get; set; }
        public bool IsPaid  { get; set; }

        public ExpenseType ExpenceType { get; set; }
        public int ExpenseId { get; set; }

        public Flat Flat { get; set; }
        public int FlatId { get; set; }
        
    }
}

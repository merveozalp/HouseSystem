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
        
       
        public double Cost { get; set; }
        public bool IsPaid  { get; set; }
        public DateTime InvoiceDate { get; set; }
        public ExpenseType ExpenceType { get; set; }
        public int ExpenseTypeId { get; set; } 

        public Flat Flat { get; set; }
        public int FlatId { get; set; }
        
    }
}

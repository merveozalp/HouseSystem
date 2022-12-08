using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Entities.Dtos
{
    public class ExpenseCreateDto
    {
        public bool IsPaid { get; set; }
        public double Cost { get; set; }
        public int ExpenseId { get; set; }

       public int FlatId { get; set; }

       public string TypeName { get; set; }

        public byte FlatNumber { get; set; }
      
    }
}

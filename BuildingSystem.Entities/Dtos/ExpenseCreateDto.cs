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
        public int ExpenseTypeId { get; set; } 
        public string ExpenseTypeName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int FlatId { get; set; }
        public byte FlatNumber { get; set; }

        public IEnumerable<ExpenseTypeDto> ExpenseTypes { get; set; }
        public IEnumerable<FlatDto> Flats { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public DateTime InvoiceDate { get; set; }
        public int FlatId { get; set; }
        public int BuildingId { get; set; }
    }
}

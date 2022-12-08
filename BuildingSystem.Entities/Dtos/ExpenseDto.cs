using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Entities.Dtos
{
    public class ExpenseDto
    {
       public int Id { get; set; }
        public bool IsPaid { get; set; }
        public double Cost { get; set; }
        public string UserName { get; set; }
        public int FlatId { get; set; }
        public byte FlatNumber { get; set; }
        public string TypeName { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Entities.Dtos
{
    public class UpdateExpenseDto
    {
        public int Id { get; set; }
        public bool IsPaid { get; set; }
        public decimal Cost { get; set; }
       
        public int ExpenseTypeId { get; set; }  
        public int FlatId { get; set; }
        public string TypeName { get; set; }

        public byte FlatNumber { get; set; }
    }
}

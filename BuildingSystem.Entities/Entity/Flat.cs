﻿//using BuildingSystem.Entities.Entity;
using BuildingSystem.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Entitiy
{
    public class Flat:Base
    {
        public Flat()
        {
            Expenses = new HashSet<Expense>();
        }
        public byte FlatNumber { get; set; }
        public bool IsEmpty { get; set; }
        public bool IsOwner { get; set; }
        public Building Building { get; set; }
        public int BuildingId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public FlatType FlatType { get; set; }
        public int FlatId { get; set;}
     



    }
}

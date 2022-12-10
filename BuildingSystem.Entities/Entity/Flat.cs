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
        //public byte FloorNumber { get; set; }
        public string FlatType { get; set; }  // 2+1 vs oluşu
        public bool IsEmpty { get; set; }
        public int HouseType { get; set; }  // kiracı,ev sahibi

        public Building Building { get; set; }
        public int BuildingId { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }

        public ICollection<Expense> Expenses { get; set; }
     



    }
}

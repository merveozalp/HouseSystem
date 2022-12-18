using BuildingSystem.Entities.Entity;
using BuildingSystem.Entities.Enum;
using BuildingSystem.UI.Enum;
using System.Collections.Generic;

namespace Entites.Entitiy
{
    public class Flat:Base
    {
        public Flat()
        {
            Expenses = new HashSet<Expense>();
        }
        public byte FlatNumber { get; set; }
        public string FlatType { get; set; }
        public byte FloorNumber{ get; set; }  // kat numarası
        public FlatIsEmpty IsEmpty { get; set; }
        public FlatIsOwner IsOwner { get; set; }
        public Building Building { get; set; }
        public int BuildingId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}

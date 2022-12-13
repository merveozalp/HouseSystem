using BuildingSystem.Entities.Entity;
using Entites.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Entities.Dtos
{
    public class FlatCreateDto
    {
        public byte FlatNumber { get; set; }
        public bool IsEmpty { get; set; }
        public string FlatType { get; set; }
        public byte FloorNumber { get; set; }

        public bool IsOwner { get; set; }
        public string UserId { get; set; }
       
        public int BuildingId { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Building> Buildings { get; set; }



    }
}

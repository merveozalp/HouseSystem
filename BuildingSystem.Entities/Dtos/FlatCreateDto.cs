using BuildingSystem.Entities.Entity;
using BuildingSystem.Entities.Enum;
using BuildingSystem.UI.Enum;
using Entites.Entitiy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Entities.Dtos
{
    public class FlatCreateDto
    {
        public byte FlatNumber { get; set; }
        public FlatIsEmpty IsEmpty { get; set; }
        public string FlatType { get; set; }
        public byte FloorNumber { get; set; }
        public FlatIsOwner IsOwner { get; set; }
        public string UserId { get; set; }
        public int BuildingId { get; set; }
    }
}

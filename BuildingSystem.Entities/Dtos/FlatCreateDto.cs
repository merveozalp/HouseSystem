using BuildingSystem.Entities.Entity;
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
        public int FlatId { get; set; }
        public byte FlatNumber { get; set; }
        public bool IsEmpty { get; set; }
        public string FlatType { get; set; }
        public byte FloorNumber { get; set; }
        public bool IsOwner { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int BuildingId { get; set; }

        public ICollection<UserDto> Users { get; set; }
        public ICollection<BuildingDto> Buildings { get; set; }
      



    }
}

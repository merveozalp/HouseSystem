using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Entities.Dtos
{
    public class FlatUpdateDto
    {
        public int Id { get; set; }
        public byte FlatNumber { get; set; }
        public bool IsEmpty { get; set; }
        public string FlatType { get; set; }
        public byte FloorNumber { get; set; }
        public bool IsOwner { get; set; }
        public string UserId { get; set; }
        public int BuildingId { get; set; }
        public int FlatId { get; set; }

        public IEnumerable<BuildingDto> Buildings { get; set; } //id
        public IEnumerable<UserDto> Users { get; set; }//id
        public ICollection<FlatDto> Flats { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Entities.Dtos
{
    public class FlatViewModel
    {
        public byte FlatNumber { get; set; }
        public bool IsEmpty { get; set; }
        public string FlatType { get; set; }
        public byte FloorNumber { get; set; }
        public bool IsOwner { get; set; }
        public string BuildingName { get; set; }
        public string UserName { get; set; }

        public string UserId { get; set; }

        public int? BuildingId { get; set; }
        public IEnumerable<UserDto> Users { get; set; }
        public IEnumerable<BuildingDto> Buildings { get; set; }
    }
}

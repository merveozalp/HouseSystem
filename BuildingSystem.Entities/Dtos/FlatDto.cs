using BuildingSystem.Entities.Enum;
using BuildingSystem.UI.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Entities.Dtos
{
    public class FlatDto
    {
        public int Id { get; set; }
        public byte FlatNumber { get; set; }
        public string FlatType { get; set; }
        public byte FloorNumber { get; set; }
        public FlatIsOwner IsOwner { get; set; }
        public FlatIsEmpty IsEmpty { get; set; }
        public string UserName { get; set; }
        public string BuildingName { get; set; }
       

      
    }
}

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
        public string HouseType { get; set; }
        public string UserId { get; set; }
       
        public int BuildingId { get; set; }
      
        public int blockId { get; set; }
      


    }
}

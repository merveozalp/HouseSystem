using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Entities.Dtos
{
    public  class BlockAndBuildingDto
    {
        public int Id { get; set; }
        public string BlockName { get; set; }
        public byte BuildingName { get; set; }
        public byte TotalFlat { get; set; }
    }
}

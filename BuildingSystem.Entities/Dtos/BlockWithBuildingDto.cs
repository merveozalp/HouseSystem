using BuildingSystem.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Entities.Dtos
{

    public class BlockWithBuildingDto
    {
        public string BlockName { get; set; }
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public IEnumerable<BuildingDto> Building { get; set; }
    }
}

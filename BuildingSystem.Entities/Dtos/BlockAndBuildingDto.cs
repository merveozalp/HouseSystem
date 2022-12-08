using BuildingSystem.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Entities.Dtos
{
    public class BlockAndBuildingDto
    {
        public BlockDto BlockName { get; set; }
        public Building Building { get; set; }
    }
}

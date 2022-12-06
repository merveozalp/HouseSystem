using BuildingSystem.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Entities.Dtos
{
    public class BuildingWithBlockDto
    {
        public List<Building> buildings { get; set; }
        public List<Block> blocks { get; set; }
    }
}

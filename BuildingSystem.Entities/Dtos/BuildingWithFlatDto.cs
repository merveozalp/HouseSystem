using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Entities.Dtos
{
    public class BuildingWithFlatDto:BuildingDto
    {
        public List<FlatDto> Flats { get; set; }
    }
}

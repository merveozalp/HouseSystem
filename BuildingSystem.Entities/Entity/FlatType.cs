using Entites.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Entities.Entity
{
    public class FlatType:Base
    {
        public string FlatTypeName { get; set; }

        public ICollection<Flat> Flats { get; set; }

    }
}

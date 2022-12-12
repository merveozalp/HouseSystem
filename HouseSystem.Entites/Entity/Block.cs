using Entites.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Entities.Entity
{
    public class Block:Base
    {
        public Block()
        {
            Buildings = new HashSet<Building>();   
        }
        public string BlockName { get; set; }

        public ICollection<Building> Buildings { get; set; }
    }
}

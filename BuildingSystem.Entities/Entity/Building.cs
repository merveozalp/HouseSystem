﻿using Entites.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Entities.Entity
{
    public class Building:Base
    {
        public Building()
        {
            Flats = new HashSet<Flat>();
        }
        public byte BuildingName { get; set; }  // 1-2-3 olarak grilecek
        public byte TotalFlat { get; set; }
        public ICollection<Flat> Flats { get; set; }

        public Block Block { get; set; }
        public int BlockId { get; set; }

    }
}

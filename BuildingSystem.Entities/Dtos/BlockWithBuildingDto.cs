﻿using BuildingSystem.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Entities.Dtos
{

    public class BlockWithBuildingDto
    {
        public Block Block { get; set; }
        public Building Building { get; set; }
    }
}

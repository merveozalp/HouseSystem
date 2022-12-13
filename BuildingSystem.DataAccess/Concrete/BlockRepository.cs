﻿using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.DataAccess.Context;
using BuildingSystem.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.DataAccess.Concrete
{
    public class BlockRepository : GenericRepository<Block>, IBlockRepository
    {

        public BlockRepository( ApplicationDbContext db) : base(db)
        {
        }

      

       
    }
}

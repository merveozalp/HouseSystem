using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.DataAccess.Context;
using BuildingSystem.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.DataAccess.Concrete
{
    public class BuildingRepository : GenericRepository<Building>, IBuildingRepository
    {
        public BuildingRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<Building> GetBuildingByIdWithFlatAsync(int buildingId)
        {
            return await _db.Buildings.Include(x=>x.Flats).Where(x=>x.Id==buildingId).SingleOrDefaultAsync();
        }
    }
}

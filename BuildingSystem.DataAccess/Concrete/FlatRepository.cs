using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.DataAccess.Context;
using Entites.Entitiy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.DataAccess.Concrete
{
    public class FlatRepository : GenericRepository<Flat>, IFlatRepository
    {
        public FlatRepository(ApplicationDbContext db) : base(db)
        {
        }

        // Blok ekledin.
        public async Task<List<Flat>> GetAllFlats()
        {
            return await _db.Flats.Include(x => x.User).Include(x=>x.Building).ThenInclude(x=>x.Block).OrderBy(x=>x.FlatNumber).ToListAsync();
        }

        public  List<Flat> GetBlockBuildingAndFlat()
        {
           return  _db.Flats.Include(x => x.Building).ThenInclude(x => x.Block).ToList();
        }
    }
}

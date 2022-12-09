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

        public async Task<List<Flat>> GetAllFlats()
        {
            return await _db.Flats.Include(x => x.User).Include(x=>x.Building).OrderBy(x=>x.FlatNumber).ToListAsync();
        }
    }
}

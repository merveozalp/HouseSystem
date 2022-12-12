using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.DataAccess.Context;
using BuildingSystem.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.DataAccess.Concrete
{
    public class FlatTypeRepository : GenericRepository<FlatType>, IFlatTypeRepository
    {
        public FlatTypeRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}

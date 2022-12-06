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
    public class MessangeRepository : GenericRepository<Messange>, IMessageRepository
    {
        public MessangeRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}

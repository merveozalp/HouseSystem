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
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}

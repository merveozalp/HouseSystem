using Entites.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Abstract
{
    public interface IRoleService
    {
       Task CreateRole (string roleName);
        Task<Role> Delete(string id);
       List<Role> GetAllRole();
    }
}

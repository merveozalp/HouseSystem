using AutoMapper;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Entities.Dtos;
using Entites.Entitiy;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Concrete
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<Role> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task CreateRole(string roleName)
        {
            await _roleManager.CreateAsync(new Role
            {
                Name = roleName,
            });

        }

        public List<Role> GetAllRole()
        {
            var roleList = _roleManager.Roles.ToList();
            return roleList;
        }
    }
}

using BuildingSystem.Entities.Dtos;
using Entites.Entitiy;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Abstract
{
    public interface IUserService
    {
        void AddAsync(UserDto dto);
        Task<SignInResult> LogIn(LoginDto LoginDto);
        Task<IEnumerable<UserDto>> GetAllAsync();

    }
}

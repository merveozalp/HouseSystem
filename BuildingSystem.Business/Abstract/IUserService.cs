using BuildingSystem.Entities.Dtos;
using Entites.Entitiy;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Abstract
{
    public interface IUserService
    {
        Task AddAsync(LoginDto loginDto);
        Task<SignInResult> LogIn(LoginDto loginDto);
        Task<List<UserDto>> GetAllAsync();
        Task UpdateUserAsync(UserDto userDto);
        Task<UserDto> FindById(string id);
        Task<UserDto> FindByName(string name);
        Task<UserDto> FindByEmail(string email);
        void Delete(string id);
        User GetUserFromSession();

    }
}

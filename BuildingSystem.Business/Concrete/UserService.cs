using AutoMapper;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.UnitOfWork;
using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.DataAccess.Concrete;
using BuildingSystem.Entities.Dtos;
using Entites.Entitiy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Concrete
{
    public class UserService : IUserService
    {
        public UserManager<User> _userManager { get; }
        public SignInManager<User> _signInManager { get; }
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IUserRepository userRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public void AddAsync(UserDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<SignInResult> LogIn(LoginDto LoginDto)
        {
            if (LoginDto.Email != null)
            {
                User user = await _userManager.FindByEmailAsync(LoginDto.Email);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                }
                SignInResult result = _signInManager.PasswordSignInAsync(user, LoginDto.Password,false,false).Result;
                return result;
            }


            return null;
        }

        public User GetUser()
        {
          var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
          var user = _userManager.FindByNameAsync(userName).Result;
          return user;
            
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var userGetAll = await _userRepository.GetAll().ToListAsync();
            var userList = _mapper.Map<IEnumerable<UserDto>>(userGetAll);
            return userList;
        }

        
    }
}

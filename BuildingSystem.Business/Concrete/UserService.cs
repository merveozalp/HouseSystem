using AutoMapper;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.UnitOfWork;
using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.Entities.Dtos;
using Entites.Entitiy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Concrete
{
    public class UserService : IUserService
    {
        public UserManager<User> _userManager { get; }
        public SignInManager<User> _signInManager { get; }
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task AddAsync(UserDto userDto)
        {
            User user = new User()
            {
                IdentityNo = userDto.IdentityNo,
                UserName = userDto.UserName,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                CarNo = userDto.CarNo,
                PhoneNumber = userDto.PhoneNumber,

            };
            IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);


        }
        public async Task<IList<string>> LogIn(LoginDto loginDto)
        {
            if (loginDto.Email != null)
            {
                User user = await _userManager.FindByEmailAsync(loginDto.Email);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                }
               SignInResult result = _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false).Result;
                IList<string> roles = await _userManager.GetRolesAsync(user);
                return roles;
            }
            return null;
        }
        public async Task<List<UserDto>> GetAllAsync()
        {
            var userGetAll = await _userRepository.GetAll().ToListAsync();
            var userList = _mapper.Map<List<UserDto>>(userGetAll);
            return userList;
        }
        public async Task UpdateUserAsync(UserDto userDto)
        {
            var user = await _userManager.FindByIdAsync(userDto.Id);
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.UserName = userDto.UserName;
            user.Email = userDto.Email;
            user.IdentityNo = userDto.IdentityNo;
            user.CarNo = userDto.CarNo;
            var result = await _userManager.UpdateAsync(user);
        }

        public async Task<UserDto> FindById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var userDto = _mapper.Map<UserDto>(user);
             return userDto;
        }
        public async Task<UserDto> FindByName(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
        public async Task<UserDto> FindByEmail(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
        public void Delete(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            _userRepository.Delete(user);
            _unitOfWork.Commit();
        }
        public User GetUserFromSession()
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = _userManager.FindByNameAsync(userName).Result;
            return user;
        }

        public async Task<IdentityResult> UserRegister(UserDto dto)
        {
            User user = new User()
            {
                IdentityNo = dto.IdentityNo,
                UserName = dto.UserName,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                CarNo = dto.CarNo,
                PhoneNumber = dto.PhoneNumber,

            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Resident");
            }
            return result;
        }
    }
}

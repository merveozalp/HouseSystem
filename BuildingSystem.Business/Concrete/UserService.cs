﻿using AutoMapper;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.UnitOfWork;
using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.Entities.Dtos;
using Entites.Entitiy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        public async Task AddAsync(LoginDto dto)
        {
            var user = _mapper.Map<User>(dto);
            var result = await _userManager.CreateAsync(user, dto.Password);
            await _userManager.AddToRoleAsync(user, "Resident");
           
        }
        public async Task<Microsoft.AspNetCore.Identity.SignInResult> LogIn(LoginDto loginDto)
        {
            if (loginDto.Email != null)
            {
                User user = await _userManager.FindByEmailAsync(loginDto.Email);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                }
                Microsoft.AspNetCore.Identity.SignInResult result = _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false).Result;
                return result;
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
    }
}

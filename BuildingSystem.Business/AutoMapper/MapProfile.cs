using AutoMapper;
using BuildingSystem.Entities.Dtos;
using BuildingSystem.Entities.Entity;
using Entites.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.AutoMapper
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Block,BlockDto>().ReverseMap();
            CreateMap<Block, BlockWithBuildingDto>().ReverseMap();
            CreateMap<Building, BuildingDto>().ReverseMap();
            CreateMap<Building, BuildingWithBlockDto>().ReverseMap();
            CreateMap<Building, BuildingWithFlatDto>().ReverseMap();
            CreateMap<Expense,ExpenseDto>().ReverseMap();
            CreateMap<ExpenseType,ExpenseDto>().ReverseMap();
            CreateMap<Flat,FlatDto>().ReverseMap();
            CreateMap<Messange,MessageDto>().ReverseMap();
            CreateMap<Role,RoleDto>().ReverseMap();
            CreateMap<User,UserDto>().ReverseMap();
           
        }
    }
}

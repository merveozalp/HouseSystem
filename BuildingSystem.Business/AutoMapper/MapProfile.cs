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
            //CreateMap<Block,BlockDto>().ReverseMap();

            //------------------------------------------------------------------------

            CreateMap<Building, BuildingDto>().ReverseMap();

            //--------------------------------------------------------------------------
            CreateMap<Expense,ExpenseDto>().ReverseMap();
            CreateMap<Expense,ExpenseCreateDto>().ReverseMap();
            CreateMap<Expense,ExpenseUpdateDto>().ReverseMap();
            //-------------------------------------------------------------------------

            CreateMap<ExpenseType,ExpenseTypeDto>().ReverseMap();
           

            //--------------------------------------------------------------------------
            CreateMap<Flat,FlatDto>().ReverseMap();
            CreateMap<Flat,FlatCreateDto>().ReverseMap();
            CreateMap<Flat,FlatUpdateDto>().ReverseMap();
            //CreateMap<Flat, BlockAndBuildingDto>().ReverseMap();
            //CreateMap<FlatType, FlatTypeDto>().ReverseMap();


            //-------------------------------------------------------------------------
            CreateMap<Message,MessageDto>().ReverseMap();
            CreateMap<Role,RoleDto>().ReverseMap();
            //CreateMap<Role,RoleAssignDto>().ReverseMap();
            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<User,LoginDto>().ReverseMap();
           
        }
    }
}

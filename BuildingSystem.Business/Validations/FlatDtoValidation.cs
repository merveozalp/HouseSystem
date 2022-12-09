using BuildingSystem.Entities.Dtos;
using Entites.Entitiy;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BuildingSystem.Business.Validations.FlatDtoValidation;

namespace BuildingSystem.Business.Validations
{
    public class FlatDtoValidation:AbstractValidator<FlatDto>
    {
        public FlatDtoValidation() 
        {
            
        }

      
            

    }
}

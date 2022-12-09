using BuildingSystem.Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Validations
{
    public class BlockDtoValidatior:AbstractValidator<BlockDto>
    {
        public BlockDtoValidatior()
        {
            RuleFor(x => x.BlockName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            
        }
    }
}

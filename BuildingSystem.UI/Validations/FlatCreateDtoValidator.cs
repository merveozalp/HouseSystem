using BuildingSystem.Entities.Dtos;
using FluentValidation;
using FluentValidation.Results;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class FlatCreateDtoValidator:AbstractValidator<FlatCreateDto>
    {
        public FlatCreateDtoValidator()
        {
            RuleFor(x => x.FlatNumber).NotEmpty().WithMessage("Zorunlu");
            RuleFor(x => x.FloorNumber).NotEmpty().WithMessage("Zorunlu");
            RuleFor(x => x.FlatType).NotEmpty().WithMessage("Zorunlu");
           
        }
      
    }
}
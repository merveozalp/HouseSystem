using BuildingSystem.Business.Validations;
using BuildingSystem.Entities.Dtos;
using FluentValidation;
using FluentValidation.Results;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class FlatCreateDtoValidator : AbstractValidator<FlatCreateDto>
    {
        public FlatCreateDtoValidator()
        {
            RuleFor(x => x.FlatNumber).NotEmpty().WithMessage("Zorunlu");
            RuleFor(x => x.FloorNumber).NotEmpty().WithMessage("Zorunlu");
            RuleFor(x => x.FlatType).NotEmpty().WithMessage("Zorunlu");
            RuleFor(x => x.BuildingId).GreaterThan(0).WithMessage("Zorunlu");
            RuleFor(x => x.UserId).NotNull().WithMessage("Zorunlu");
        }

    }
}
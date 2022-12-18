using BuildingSystem.Entities.Dtos;
using FluentValidation;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class ExpenseCreateValidator : AbstractValidator<ExpenseCreateDto>
    {
        public ExpenseCreateValidator()
        {
            
            RuleFor(x => x.Cost).NotEmpty().WithMessage(" �deme Miktar�n� Giriniz.");
            RuleFor(x => x.FlatId).NotEmpty().WithMessage(" Daire Numaras�n� Giriniz.");
            RuleFor(x => x.ExpenseTypeId).NotEmpty().WithMessage(" Gider Se�iniz.");
            RuleFor(x => x.BuildingId).NotEmpty().WithMessage(" Gider Se�iniz.");
        }

    }
}
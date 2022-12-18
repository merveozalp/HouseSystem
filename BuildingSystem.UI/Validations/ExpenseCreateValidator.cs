using BuildingSystem.Entities.Dtos;
using FluentValidation;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class ExpenseCreateValidator : AbstractValidator<ExpenseCreateDto>
    {
        public ExpenseCreateValidator()
        {
            
            RuleFor(x => x.Cost).NotEmpty().WithMessage(" Ödeme Miktarýný Giriniz.");
            RuleFor(x => x.FlatId).NotEmpty().WithMessage(" Daire Numarasýný Giriniz.");
            RuleFor(x => x.ExpenseTypeId).NotEmpty().WithMessage(" Gider Seçiniz.");
            RuleFor(x => x.BuildingId).NotEmpty().WithMessage(" Gider Seçiniz.");
        }

    }
}
using BuildingSystem.Entities.Dtos;
using FluentValidation;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class ExpenseUpdateValidator : AbstractValidator<ExpenseUpdateDto>
    {
        public ExpenseUpdateValidator()
        {
            //RuleFor(x => x.IsPaid).NotEmpty().WithMessage("Ödeme Durumunu Giriniz.");
            //RuleFor(x => x.Cost).NotEmpty().WithMessage(" Ödeme Miktarýný Giriniz.");
            //RuleForEach(x => x.Flats).ChildRules(v =>
            //{
            //    v.RuleFor(v => v.FlatNumber).NotEmpty().NotNull();
            //});
         
            //RuleForEach(x => x.ExpenseTypes).ChildRules(v => { v.RuleFor(v => v.ExpenseTypeName).NotEmpty().NotNull(); });
            //RuleForEach(x => x.Buildings).ChildRules(building =>
            //{
            //    building.RuleFor(x => x.BuildingName).NotEmpty();
            //});
        }

    }
}
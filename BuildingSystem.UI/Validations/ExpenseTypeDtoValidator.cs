using BuildingSystem.Entities.Dtos;
using FluentValidation;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class ExpenseTypeDtoValidator : AbstractValidator<ExpenseTypeDto>
    {
        public ExpenseTypeDtoValidator()
        {
            RuleFor(x => x.ExpenseTypeName).NotNull().WithMessage("Lütfen Boþ Geçmeyiniz.");
            RuleFor(x => x.ExpenseTypeName).MaximumLength(10).WithMessage("En fazla 10 Karakter girebilirsiniz.");
            RuleFor(x => x.ExpenseTypeName).MinimumLength(2).WithMessage("En Az 2 Karakter girebilirsiniz.");
        }

    }
}
using BuildingSystem.Entities.Dtos;
using FluentValidation;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage("Lütfen Boþ Geçmeyiniz ");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Mail Adresinizi doðru Giriniz.");
            RuleFor(x => x.Password).NotNull().WithMessage("Þifrenizi Giriniz. ");
        }

    }
}
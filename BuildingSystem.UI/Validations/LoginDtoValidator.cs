using BuildingSystem.Entities.Dtos;
using FluentValidation;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage("L�tfen Bo� Ge�meyiniz ");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Mail Adresinizi do�ru Giriniz.");
            RuleFor(x => x.Password).NotNull().WithMessage("�ifrenizi Giriniz. ");
        }

    }
}
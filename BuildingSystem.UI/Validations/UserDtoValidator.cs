using BuildingSystem.Entities.Dtos;
using FluentValidation;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage("�sminizi Giriniz.");
            RuleFor(x => x.FirstName).MaximumLength(200).WithMessage("Karakter say�n�z fazla kontrol ediniz.");
            RuleFor(x => x.LastName).NotNull().WithMessage("L�tfen Soyisminizi Giriniz.");
            RuleFor(x => x.LastName).MaximumLength(200).WithMessage("Karakter say�n�z fazla kontrol ediniz ");
            RuleFor(x => x.UserName).NotNull().WithMessage("L�tfen Kullan�c� �sminizi Giriniz.");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("Kullan�c� Ad� uzunlu�unuz Fazla Kontrol Ediniz.");
            RuleFor(x => x.Email).NotNull().WithMessage("Email Adresini Bo� Ge�emezsiniz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage(" Email Adresinizi Do�ru Giriniz.");
            RuleFor(x => x.IdentityNo).NotNull().WithMessage("L�tfen Kimlik Numaran�z� Yaz�n�z.");
            RuleFor(x => x.IdentityNo).MaximumLength(11).WithMessage("Kimlik Numaran�z�n uzunlu�una Dikkat Ediniz.");
            RuleFor(x => x.CarNo).NotNull().WithMessage("Araba Plakan�z� Giriniz. ");
            RuleFor(x => x.CarNo).MaximumLength(10).WithMessage("Araba Plaka Uzunlu�unuzu Kontrol Ediniz.");
            RuleFor(x => x.Password).MaximumLength(10).WithMessage("L�tfen �ifre giriniz..");
        }
    }
}
using BuildingSystem.Entities.Dtos;
using FluentValidation;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class MessageDtoValidator : AbstractValidator<MessageDto>
    {
        public MessageDtoValidator()
        {
            RuleFor(x => x.MessageContent).NotNull().WithMessage(" Mesaj Baþlýðý Giriniz. ");
            RuleFor(x => x.MessageContent).MaximumLength(20).WithMessage("Mesaj Baþlýðý Karakter Sayýsýna Dikkat Ediniz.");
            RuleFor(x => x.Body).MaximumLength(1000).WithMessage("Mesaj içeriðiniz Çok Uzun");
            RuleFor(x => x.ReceiverMail).NotNull().WithMessage("Lütfen Göndereceðiniz Kiþiyi Giriniz.");
        }

    }
}
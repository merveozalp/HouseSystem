using BuildingSystem.Business.Abstract;
using BuildingSystem.Entities.Dtos;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Threading.Tasks;

namespace BuildingSystem.UI.Controllers
{
    public class MailController : Controller

      
    {
        private readonly IMessageService _messageService;

        public MailController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(MessageDto messageDto)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Site Yönetimi","B202102043@subu.edu.tr");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", messageDto.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyByilder = new BodyBuilder();
            bodyByilder.TextBody=messageDto.MessageContent;
            mimeMessage.Body = bodyByilder.ToMessageBody();

            mimeMessage.Subject = messageDto.MessageContent;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("B202102043@subu.edu.tr", "mbduhgnbuzuautxy");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }

        public async Task<IActionResult> Inbox() 
        {
            var messageList = await _messageService.FromGetAll();
            return View(messageList);
        }
    }
}

using BuildingSystem.Business.Abstract;
using BuildingSystem.Entities.Dtos;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingSystem.UI.Controllers
{
    public class MailController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        private readonly IExpenseService expenseService;
        public MailController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
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
            bodyByilder.TextBody = messageDto.Body;
            mimeMessage.Body = bodyByilder.ToMessageBody();


            mimeMessage.Subject = messageDto.MessageContent;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("B202102043@subu.edu.tr", "mbduhgnbuzuautxy");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return RedirectToAction("Inbox");
        }

        [HttpGet]
        public async Task<IActionResult> Inbox()
        {
            var user = _userService.GetUserFromSession();
            var allMessages = await _messageService.GetAllAsync();
            if (allMessages != null)
            {
                var messageList = allMessages.Where(m => m.ReceiverMail == user.Id).ToList();
                var inboxList = await _messageService.GetListInbox(messageList);
                return View(inboxList);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Outbox()
        {
            var user = _userService.GetUserFromSession();
            var allMessages = await _messageService.GetAllAsync();
            if (allMessages!= null)
            {
                var messageList = allMessages.Where(m => m.SenderMail == user.Id).ToList();
                var outBoxList = await _messageService.GetListOutbox(messageList);
                return View(outBoxList);
            }
            return View();
        }

        //---------------------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            var userList = await _userService.GetAllAsync();
            var messageDto = new MessageDto
            {
                Users = userList
            };
            return View(messageDto);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageDto message)
        {
            var user = _userService.GetUserFromSession();
            message.SenderMail = user.Id;
            await _messageService.AddAsync(message);
            return RedirectToAction("OutBox");
        }

    }
}

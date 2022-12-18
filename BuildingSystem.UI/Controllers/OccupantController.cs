using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.Concrete;
using BuildingSystem.Entities.Dtos;
using BuildingSystem.UI.Filters;
using Entites.Entitiy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingSystem.UI.Controllers
{
    //[Authorize(Roles = "Yönetici")]
   
    public class OccupantController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserService _userService;
        private readonly IExpenseService _expenseService;
        private readonly IMessageService _messageService;
        public OccupantController(UserManager<User> userManager, SignInManager<User> signInManager, IUserService userService, IExpenseService expenseService, IMessageService messageService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _expenseService = expenseService;
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetUnpaidExpense()
        {
            var user = _userService.GetUserFromSession();
            var expenses = await _expenseService.GetAllExpenses();
            var expensesOfDebt = expenses.Where(x => x.UserName == user.UserName && !x.IsPaid).ToList();
            return View(expensesOfDebt);
        }
        public async Task<IActionResult> GetPaidExpense()
        {
            var user = _userService.GetUserFromSession();
            var expenses = await _expenseService.GetAllExpenses();
            var expensesOfDebt = expenses.Where(x => x.UserName == user.UserName && x.IsPaid).ToList();
            return View(expensesOfDebt);
        }

        public async Task<IActionResult> Inbox()
        {
            var user = _userService.GetUserFromSession();
            var allMessages = await _messageService.GetAllAsync();
            if (allMessages != null)
            {
                var messageList = allMessages.Where(x => x.ReceiverMail == user.Id).ToList();
                List<MessageDto> messageDtos = new List<MessageDto>();
                foreach (var item in messageList)
                {
                    var sender = await _userService.FindById(item.SenderMail);
                    var messageDto = new MessageDto
                    {
                        Id = item.Id,
                        SenderMail = item.SenderMail,
                        ReceiverMail = item.ReceiverMail,
                        MessageContent = item.MessageContent,
                        Body = item.Body,
                        UserName = sender.UserName
                    };
                    messageDtos.Add(messageDto);
                }
                return View(messageDtos);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Outbox()
        {
            var user = _userService.GetUserFromSession();
            var allMessages = await _messageService.GetAllAsync();
            if (allMessages != null)
            {
                var messageList = allMessages.Where(x => x.SenderMail == user.Id).ToList();
                List<MessageDto> messageDtos = new List<MessageDto>();
                foreach (var item in messageList)
                {
                    var receiver = await _userService.FindById(item.ReceiverMail);
                    var messageDto = new MessageDto
                    {
                        Id = item.Id,
                        SenderMail = item.SenderMail,
                        ReceiverMail = item.ReceiverMail,
                        MessageContent = item.MessageContent,
                        UserName = receiver.UserName,
                        Body = item.Body
                    };
                    messageDtos.Add(messageDto);
                }
                return View(messageDtos);
            }
            return View();
        }

        [HttpGet]
        public IActionResult SendMessageToAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessageToAdmin(MessageDto message)
        {
            var user = _userService.GetUserFromSession();
            message.SenderMail = user.Id;
            message.ReceiverMail = "f4003c4c-8e15-4b1c-835d-21d2a42fce7a"; // Kendi tanımladıüım Admin Id
            await _messageService.AddAsync(message);
            return RedirectToAction("OutBox");
        }
    }
}

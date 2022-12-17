using AutoMapper;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.UnitOfWork;
using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.Entities.Dtos;
using Entites.Entitiy;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Concrete
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserManager<User> _userManager;


        public ExpenseService(IExpenseRepository expenseRepository, IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _expenseRepository = expenseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<ExpenseCreateDto> AddAsync(ExpenseCreateDto expenseCreateDto)
        {
            var entityDto = _mapper.Map<Expense>(expenseCreateDto);
            await _expenseRepository.AddAsync(entityDto);
            await _unitOfWork.CommitAsync();
            return expenseCreateDto;
        }

        public void DeleteAsync(int id)
        {
            var expense =  _expenseRepository.GetById(id).Result;
            _expenseRepository.Delete(expense);
            _unitOfWork.Commit();
        }

        public async Task<List<ExpenseDto>> GetAllAsync()
        {
            var expenseList = await _expenseRepository.GetAll().ToListAsync();
            var expenseDto = _mapper.Map<List<ExpenseDto>>(expenseList);
            return expenseDto;
        }

        public async Task<List<ExpenseDto>> GetAllExpenses()
        {
            var expenses = await _expenseRepository.GetAllExpenses();
            var ExpensesDto = expenses.Select(x=> new ExpenseDto
            {
                Id=x.Id,
                IsPaid =x.IsPaid,
                Cost=x.Cost,
                InvoiceDate=x.InvoiceDate,
                UserName=x.Flat.User.UserName,
                FlatNumber=x.Flat.FlatNumber,
                ExpenseTypeName=x.ExpenceType.ExpenseTypeName
            }).ToList();
            return ExpensesDto;
        }

        public async Task<ExpenseDto> GetById(int Id)
        {
            var blocks = await _expenseRepository.GetById(Id);
            var blockDto =_mapper.Map<ExpenseDto>(blocks);
            return blockDto;
        }

        public async Task SendMail()
        {
            var expenseList = await  _expenseRepository.GetAllExpenses();
            foreach (var item in expenseList.Where(x => !x.IsPaid))
            {
                var ReceiverEmail = item.Flat.User.Email;
                var ExpenseType = item.ExpenceType.ExpenseTypeName;
                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("Site Yönetimi", "B202102043@subu.edu.tr");
                mimeMessage.From.Add(mailboxAddressFrom);

                MailboxAddress mailboxAddressTo = new MailboxAddress("User", ReceiverEmail);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyByilder = new BodyBuilder();

                bodyByilder.TextBody = ExpenseType + " " + item.Cost + "TL" + " " + "Tutarıda Ödenmemiş Faturanız mecvuttur";
                mimeMessage.Body = bodyByilder.ToMessageBody();
                mimeMessage.Subject = "Site Yönetimi";

                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("B202102043@subu.edu.tr", "mbduhgnbuzuautxy");
                client.Send(mimeMessage);
               

            }

           

        }
        public void UpdateAsync(ExpenseUpdateDto expenseCreateDto)
        {
            var entityDto = _mapper.Map<Expense>(expenseCreateDto);
            _expenseRepository.Update(entityDto);
            _unitOfWork.Commit();
        }
    }
}

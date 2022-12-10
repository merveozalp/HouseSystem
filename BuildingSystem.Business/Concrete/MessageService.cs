using AutoMapper;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.UnitOfWork;
using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        

        public MessageService(IMessageRepository messageRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
           
        }

        public Task<MessageDto> AddAsync(MessageDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MessageDto>> FromGetAll()
        {
            var getAllmessage =  await _messageRepository.GetAll().Where(x => x.ReceiverMail == "B202102043@subu.edu.tr").ToListAsync();
            var messageDto = _mapper.Map<IEnumerable<MessageDto>>(getAllmessage);
            return messageDto;

        }

        public Task<MessageDto> GetById(int Id)
        {
            throw new NotImplementedException();
        }

     

        public Task UpdateAsync(MessageDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

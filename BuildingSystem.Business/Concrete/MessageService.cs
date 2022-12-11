﻿using AutoMapper;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.UnitOfWork;
using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.Entities.Dtos;
using BuildingSystem.Entities.Entity;
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
        private readonly IUserService _userService;


        public MessageService(IMessageRepository messageRepository, IMapper mapper, IUnitOfWork unitOfWork, IUserService userService)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<MessageDto> AddAsync(MessageDto dto)
        {
            var message = _mapper.Map<Message>(dto);
            await _messageRepository.AddAsync(message);
            await _unitOfWork.CommitAsync();
            return dto;
        }

        public void Delete(int id)
        {
            var message = _messageRepository.GetById(id).Result;
            _messageRepository.Delete(message);
            _unitOfWork.Commit();
        }

        public async Task<IEnumerable<MessageDto>> FromGetAll()
        {
            var getAllmessage =  await _messageRepository.GetAll().Where(x => x.ReceiverMail == "B202102043@subu.edu.tr").ToListAsync();
            var messageDto = _mapper.Map<IEnumerable<MessageDto>>(getAllmessage);
            return messageDto;

        }

        public async Task<List<MessageDto>> GetAllAsync()
        {
            var messageAll = await _messageRepository.GetAll().ToListAsync();
            var messegeDto = _mapper.Map<List<MessageDto>>(messageAll);
            return messegeDto;

        }

        public async Task<MessageDto> GetById(int id)
        {
            var message = await _messageRepository.GetById(id);
            var messageDto = _mapper.Map<MessageDto>(message);
            return messageDto;
        }

        public async Task<List<MessageDto>> GetListInbox(List<MessageDto> messageList)
        {
            List<MessageDto> messageDtos = new List<MessageDto>();
            foreach (var item in messageList)
            {
                var sender = await _userService.FindById(item.SenderMail);
                var messageDto = new MessageDto
                {
                   // Id = item.Id,
                    SenderMail = item.SenderMail,
                    ReceiverMail = item.ReceiverMail,
                    MessageContent = item.MessageContent,
                    Body = item.Body,
                    UserName = sender.UserName
                };
                messageDtos.Add(messageDto);
            }
            return messageDtos;
        }

        public async Task<List<MessageDto>> GetListOutbox(List<MessageDto> messageList)
        {
            List<MessageDto> messageDtos = new List<MessageDto>();
            foreach (var item in messageList)
            {
                var reciever = await _userService.FindById(item.ReceiverMail);
                var messageDto = new MessageDto
                {
                   // Id = item.Id,
                    SenderMail = item.SenderMail,
                    ReceiverMail = item.ReceiverMail,
                    MessageContent = item.MessageContent,
                    Body=item.Body,
                    UserName = reciever.UserName
                };
                messageDtos.Add(messageDto);
            }
            return messageDtos;
        }

        public async Task<IEnumerable<MessageDto>> ToGetAll()
        {
            var getAllmessage = await _messageRepository.GetAll().Where(x => x.SenderMail == "B202102043@subu.edu.tr").ToListAsync();
            var messageDto = _mapper.Map<IEnumerable<MessageDto>>(getAllmessage);
            return messageDto;
        }

        public void Update(MessageDto dto)
        {
            var messageDto = _mapper.Map<Message>(dto);
            _messageRepository.Update(messageDto);
            _unitOfWork.Commit();
        }
    }
}

using BuildingSystem.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Abstract
{
    public interface IMessageService
    {
        Task<MessageDto> GetById(int id);
        Task<List<MessageDto>> GetAllAsync();
        Task<IEnumerable<MessageDto>> FromGetAll();
        Task<IEnumerable<MessageDto>> ToGetAll();
        Task<MessageDto> AddAsync(MessageDto messageDto);
        void Update(MessageDto messageDto);
        void Delete(int id);

        Task<List<MessageDto>> GetListOutbox(List<MessageDto> messageList);
        Task<List<MessageDto>> GetListInbox(List<MessageDto> messageList);


    }
}

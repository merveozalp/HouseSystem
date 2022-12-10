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
        Task<MessageDto> GetById(int Id);
        Task<IEnumerable<MessageDto>> FromGetAll();
        Task<MessageDto> AddAsync(MessageDto dto);
        Task UpdateAsync(MessageDto dto);
        Task DeleteAsync(int id);

        
    }
}

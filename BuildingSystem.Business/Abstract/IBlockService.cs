using BuildingSystem.Entities.Dtos;
using BuildingSystem.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Abstract
{
    public interface IBlockService
    {
        Task<BlockDto> GetById(int Id);
        Task<IEnumerable<BlockDto>> GetAllAsync();
        Task<BlockDto> AddAsync(BlockDto blockDto);
        Task UpdateAsync(BlockDto blockDto);
        Task Delete(int id);

       


    }
}

using BuildingSystem.Entities.Dtos;
using Entites.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Abstract
{
    public interface IFlatService
    {
        Task<FlatDto> GetById(int id);
        Task<List<FlatDto>> GetAllAsync();
        Task AddAsync(FlatCreateDto flatCreateDto);
        void UpdateAsync(FlatUpdateDto flatUpdateDto);
        void DeleteAsync(int id);
       
        Task<List<FlatDto>> GetAllFlatsWithRelation();
    }
}

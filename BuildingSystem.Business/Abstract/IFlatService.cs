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
        Task<IEnumerable<FlatDto>> GetAllAsync();
        Task<FlatCreateDto> AddAsync(FlatCreateDto flatCreateDto);
        Task UpdateAsync(FlatUpdateDto flatUpdateDto);
        Task DeleteAsync(int id);
        List<FlatDto> GetBlockBuildingAndFlat();
        Task<List<FlatDto>> GetAllFlats();
    }
}

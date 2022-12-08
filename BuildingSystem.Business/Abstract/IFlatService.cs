using BuildingSystem.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Abstract
{
    public interface IFlatService
    {
        Task<FlatDto> GetById(int Id);
        Task<IEnumerable<FlatDto>> GetAllAsync();
        Task<FlatCreateDto> AddAsync(FlatCreateDto dto);
        Task UpdateAsync(FlatUpdateDto dto);
        Task DeleteAsync(FlatDto dto);

        Task<FlatDto> GetAllFlats();
    }
}

using BuildingSystem.Entities.Dtos;
using BuildingSystem.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Abstract
{
    public interface IBuildingService
    {
        Task<BuildingDto> GetById(int Id);
        Task<IEnumerable<BuildingDto>> GetAllAsync();
        Task<BuildingDto> AddAsync(BuildingDto dto);
        void Update(BuildingDto dto);
        void Delete(int id);
        //Task<BuildingWithFlatDto> GetBuildingByIdWithFlatAsync(int buildingId);
    }
}

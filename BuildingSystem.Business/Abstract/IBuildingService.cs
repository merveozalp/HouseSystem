using BuildingSystem.Entities.Dtos;
using BuildingSystem.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Abstract
{
    public interface IBuildingService:IService<Building>
    {
        Task<BuildingWithFlatDto> GetBuildingByIdWithFlatAsync(int buildingId);
    }
}

using AutoMapper;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.UnitOfWork;
using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.Entities.Dtos;
using BuildingSystem.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Concrete
{
    public class BuildingService : Service<Building>, IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;
        public BuildingService(IGenericRepository<Building> repository, IUnitOfWork unitOfWork, IBuildingRepository buildingRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }

        public async Task<BuildingWithFlatDto> GetBuildingByIdWithFlatAsync(int buildingId)
        {
            var building = await _buildingRepository.GetBuildingByIdWithFlatAsync(buildingId);
            var buildingDto = _mapper.Map<BuildingWithFlatDto>(building);
            return buildingDto;
        }

        public Task<List<BuildingWithBlockDto>> GetBuildingWithBlockAsync()
        {
            throw new NotImplementedException();
        }
    }
}

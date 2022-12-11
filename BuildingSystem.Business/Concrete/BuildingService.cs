using AutoMapper;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.UnitOfWork;
using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.DataAccess.Concrete;
using BuildingSystem.Entities.Dtos;
using BuildingSystem.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Concrete
{
    public class BuildingService :IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public BuildingService(IUnitOfWork unitOfWork, IBuildingRepository buildingRepository, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }

        public async Task<BuildingDto> AddAsync(BuildingDto dto)
        {
            var entityDto = _mapper.Map<Building>(dto);
            await _buildingRepository.AddAsync(entityDto);
            await _unitOfWork.CommitAsync();
            return dto;
        }

        public void Delete(int id)
        {
            var building =  _buildingRepository.GetById(id).Result;
            _buildingRepository.Delete(building);
            _unitOfWork.Commit();
            
         }

        public async Task<IEnumerable<BuildingDto>> GetAllAsync()
        {
            var buildingList = await _buildingRepository.GetAll().ToListAsync();
            var buildingDto = _mapper.Map<IEnumerable<BuildingDto>>(buildingList);
            return buildingDto;
        }

        //public async Task<BuildingWithFlatDto> GetBuildingByIdWithFlatAsync(int buildingId)
        //{
        //    var building = await _buildingRepository.GetBuildingByIdWithFlatAsync(buildingId);
        //    var buildingDto = _mapper.Map<BuildingWithFlatDto>(building);
        //    return buildingDto;
        //}

        public async Task<BuildingDto> GetById(int Id)
        {
            var buildings = await _buildingRepository.GetById(Id);
            var buildingDto = _mapper.Map<BuildingDto>(buildings);
            return buildingDto;
        }

        public void Update(BuildingDto dto)
        {
            var entity = _mapper.Map<Building>(dto);
            _buildingRepository.Update(entity);
             _unitOfWork.Commit();
        }
    }
}

using AutoMapper;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.UnitOfWork;
using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.Entities.Dtos;
using Entites.Entitiy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Concrete
{
    public class FlatService : IFlatService
    {
        private readonly IFlatRepository _flatRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBuildingService buildingService;

        public FlatService(IFlatRepository flatRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _flatRepository = flatRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<FlatCreateDto> AddAsync(FlatCreateDto flatCreateDto)
        {
           
            var entityDto = _mapper.Map<Flat>(flatCreateDto);
            await _flatRepository.AddAsync(entityDto);
            await _unitOfWork.CommitAsync();
            return flatCreateDto;
        }

        public void DeleteAsync(int id)
        {
            var flat = _flatRepository.GetById(id).Result;
            _flatRepository.Delete(flat);
            _unitOfWork.Commit();
        }

        public async Task<List<FlatDto>> GetAllAsync()
        {
            var flatList = await _flatRepository.GetAll().ToListAsync();
            var flatDto = _mapper.Map<List<FlatDto>>(flatList);
            return flatDto;
        }

        public async Task<List<FlatDto>> GetAllFlatsWithRelation()
        {
            var flat = await _flatRepository.GetAllFlatsWithRelation();
            var flatsDto = flat.Select(x=> new FlatDto()
            { 
                Id = x.Id,
                FlatNumber=x.FlatNumber,
                FlatType=x.FlatType,
                IsEmpty=x.IsEmpty,
                UserName=x.User.UserName,
                BuildingName=x.Building.BuildingName,
               
                
            }).ToList();

            return flatsDto;
        }

        public async Task<FlatDto> GetById(int id)
        {
            var flats = await _flatRepository.GetById(id);
            var flatDto = _mapper.Map<FlatDto>(flats);
            return flatDto;
        }

        public void UpdateAsync(FlatUpdateDto flatUpdateDto)
        {
            var entityDto = _mapper.Map<Flat>(flatUpdateDto);
            _flatRepository.Update(entityDto);
            _unitOfWork.Commit();
        }
    }
}

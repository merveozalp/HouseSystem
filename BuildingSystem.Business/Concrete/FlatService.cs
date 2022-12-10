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

        public async Task<FlatCreateDto> AddAsync(FlatCreateDto dto)
        {
           
            var entityDto = _mapper.Map<Flat>(dto);
            await _flatRepository.AddAsync(entityDto);
            await _unitOfWork.CommitAsync();
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var flat = await _flatRepository.GetById(id);
            _flatRepository.Delete(flat);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<FlatDto>> GetAllAsync()
        {
            var flatList = await _flatRepository.GetAll().ToListAsync();
            var flatDto = _mapper.Map<IEnumerable<FlatDto>>(flatList);
            return flatDto;
        }

        public async Task<List<FlatDto>> GetAllFlats()
        {
            var flat = await _flatRepository.GetAllFlats();
            var flatsDto = flat.Select(x=> new FlatDto()
            { 
                Id = x.Id,
                FlatNumber=x.FlatNumber,
                FlatType=x.FlatType,
                IsEmpty=x.IsEmpty,
                UserName=x.User.UserName,
                BuildingName=x.Building.BuildingName
            }).ToList();

            return flatsDto;
        }

        public async Task<FlatDto> GetById(int Id)
        {
            var flats = await _flatRepository.GetById(Id);
            var flatDto = _mapper.Map<FlatDto>(flats);
            return flatDto;
        }

        public async Task UpdateAsync(FlatUpdateDto dto)
        {
            var entityDto = _mapper.Map<Flat>(dto);
            _flatRepository.Update(entityDto);
            await _unitOfWork.CommitAsync();
        }
    }
}

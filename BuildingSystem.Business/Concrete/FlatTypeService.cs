using AutoMapper;
using BuildingSystem.Business.Abstract;
using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Concrete
{
    public class FlatTypeService : IFlatTypeService
    {
        private readonly IFlatTypeRepository _flatTypeRepository;
        private readonly IMapper _mapper;

        public FlatTypeService(IMapper mapper, IFlatTypeRepository flatTypeRepository)
        {

            _mapper = mapper;
            _flatTypeRepository = flatTypeRepository;
        }

        public async Task<IEnumerable<FlatTypeDto>> GetAllAsync()
        {
            var flatTypeList = await _flatTypeRepository.GetAll().ToListAsync();
            var flatTypeDto = _mapper.Map<IEnumerable<FlatTypeDto>>(flatTypeList);
            return flatTypeDto;
        }
    }
}

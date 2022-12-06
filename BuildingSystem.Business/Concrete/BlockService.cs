using AutoMapper;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.UnitOfWork;
using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.Entities.Dtos;
using BuildingSystem.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Concrete
{
    public class BlockService : Service<Block>, IBlockService
    {
        private readonly IBlockRepository _blockRepository;
        private readonly IMapper _mapper;

        public BlockService(IGenericRepository<Block> repository, IUnitOfWork unitOfWork, IBlockRepository blockRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _blockRepository = blockRepository;
            _mapper = mapper;
        }

        

        public async Task<List<BlockWithBuildingDto>> GetBlockWithBuldingAsync()
        {
            var block = await _blockRepository.GetBlockWithBuldingAsync();
            var blockDto = _mapper.Map<List<BlockWithBuildingDto>>(block);
            return blockDto.ToList();
        }

        public Task<Block> GetsingleBlocByIdkWithBulding(int blockId)
        {
            throw new NotImplementedException();
        }
    }
}

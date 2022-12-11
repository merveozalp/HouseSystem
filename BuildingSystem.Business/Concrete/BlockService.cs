using AutoMapper;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.UnitOfWork;
using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.Entities.Dtos;
using BuildingSystem.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Concrete
{
    public class BlockService : IBlockService
    {
        private readonly IBlockRepository _blockRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public BlockService(IUnitOfWork unitOfWork, IBlockRepository blockRepository, IMapper mapper)
        {
           
            _blockRepository = blockRepository;
            _mapper = mapper;
            _unitOfWork=unitOfWork;
        }
        public async Task<BlockDto> AddAsync(BlockDto dto)
        {
            var entityDto = _mapper.Map<Block>(dto);
            await _blockRepository.AddAsync(entityDto);
            await _unitOfWork.CommitAsync();
            return dto;
        }
        public async Task Delete(int id)
        {
            var block =  await _blockRepository.GetById(id);
            _blockRepository.Delete(block);
             _unitOfWork.Commit();
        }

        public async Task<IEnumerable<BlockDto>> GetAllAsync()
        {
           
           var blockList = await _blockRepository.GetAll().ToListAsync();
           return _mapper.Map<List<BlockDto>>(blockList);

        }

        public async Task<List<BlockWithBuildingDto>> GetBlockWithBuldingAsync()
        {
            var block = await _blockRepository.GetBlockWithBuldingAsync();
            var blockDto = block.Select(b => new BlockWithBuildingDto()
            {
                BlockName = b.BlockName,
                BuildingName = b.Buildings.First().BuildingName,
            }).ToList();

            return blockDto;
        }

        public async Task<BlockDto> GetById(int Id)
        {
           var block = await _blockRepository.GetById(Id);
            var blockDto = _mapper.Map<BlockDto>(block);
            return blockDto;
        }

        public async Task UpdateAsync(BlockDto dto)
        {
            var entity = _mapper.Map<Block>(dto);
            _blockRepository.Update(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}

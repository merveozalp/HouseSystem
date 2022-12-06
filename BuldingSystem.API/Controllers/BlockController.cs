using AutoMapper;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Entities.Dtos;
using BuildingSystem.Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuldingSystem.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BlockController : ControllerBase
    {
        private readonly IBlockService _blockService;
        private readonly IMapper _mapper;

        public BlockController(IBlockService blockService, IMapper mapper)
        {
            _blockService = blockService;
            _mapper = mapper;
        }
        // Get api/blocks
        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
         var blocks = await _blockService.GetAllAsync();
            var blocksDto = _mapper.Map<List<BlockDto>>(blocks.ToList());
            return Ok(blocksDto);
        }
        // Get /api/blocks/5 
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var blocks = await _blockService.GetById(Id);
            var blocksDto = _mapper.Map<BlockDto>(blocks);
            return Ok(blocksDto);
        }

        [HttpPost]
        public async Task<IActionResult> Save(BlockDto blockDto)
        {
            var blocks = await _blockService.AddAsync(_mapper.Map<Block>(blockDto)); // add mototu block istiyor ben dto gönderdiğim için
                                                                                     // başta blockdto => block dönüştürdüm. 
            var blocksDto = _mapper.Map<BlockDto>(blocks);
            return Ok(blocksDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(BlockDto blockDto)
        {
            await _blockService.UpdateAsync(_mapper.Map<Block>(blockDto)); 
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var block = await _blockService.GetById(id);
            await _blockService.DeleteAsync(block);
            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBlockWithBuilding()
        {
          var ListBlock=  await _blockService.GetBlockWithBuldingAsync();
            return Ok(ListBlock);
        }
    }
}

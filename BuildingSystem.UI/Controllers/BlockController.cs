using AutoMapper;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.Concrete;
using BuildingSystem.Entities.Dtos;
using BuildingSystem.Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingSystem.UI.Controllers
{
    public class BlockController : Controller
    {
        private readonly IBlockService _blockService;
        private readonly IMapper _mapper;

        public BlockController(IBlockService blockService, IMapper mappper)
        {
            _blockService = blockService;
            _mapper = mappper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blocks = await _blockService.GetAllAsync();
            var blocksDto = _mapper.Map<List<BlockDto>>(blocks.ToList());
            return View(blocksDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            var buildings = await _blockService.GetById(Id);
            var buildingsDto = _mapper.Map<BuildingDto>(buildings);
            return View(buildingsDto);
        }

        [HttpGet]
        public IActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(BlockDto blockDto)
        {
            var block = await _blockService.AddAsync(_mapper.Map<Block>(blockDto));
            var blocksDto = _mapper.Map<Block>(blockDto);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var blocks = await _blockService.GetById(id);
            if (blocks == null) return RedirectToAction("GetAll");
            return View(blocks);
        }

        [HttpPost]
        // Update metot hatalı Servisleri güncellemen lazım.
        public IActionResult Update(BlockDto blockDto)
        {
            var blocksDto = _mapper.Map<Block>(blockDto);
            _blockService.UpdateAsync(blocksDto);
            return RedirectToAction("Getall");
        }

        [HttpGet]
        public async  Task<IActionResult> Delete(int id)
        {
            var blocks = await _blockService.GetById(id);
            _blockService.DeleteAsync(blocks);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> GetBlockWithBuldingAsync()
        {
           var blockWithBuilding =  await _blockService.GetBlockWithBuldingAsync();
           return View(blockWithBuilding);
        }


    }
}

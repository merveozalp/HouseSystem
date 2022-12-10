using AutoMapper;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.Concrete;
using BuildingSystem.Entities.Dtos;
using BuildingSystem.Entities.Entity;
using BuildingSystem.UI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingSystem.UI.Controllers
{
    [Validatefilter]
    public class BlockController : Controller
    {
        private readonly IBlockService _blockService;
        

        public BlockController(IBlockService blockService)
        {
            _blockService = blockService;
           
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlock()
        {
            var blocks = await _blockService.GetAllAsync();
            return View(blocks);
        }

      
        [HttpGet]
        public IActionResult AddBlock()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBlock(BlockDto blockDto)
        {
            var block = await _blockService.AddAsync(blockDto);
            return RedirectToAction("GetAllBlock");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBlock(int id)
        {
            var blocks = await _blockService.GetById(id);
            if (blocks == null) return RedirectToAction("GetAllBlock");
            return View(blocks);
        }

        [HttpPost]
        // Update metot hatalı Servisleri güncellemen lazım.
        public IActionResult UpdateBlock(BlockDto blockDto)
        {
            _blockService.UpdateAsync(blockDto);
            return RedirectToAction("GetAllBlock");
        }

        [HttpGet]
        public async  Task<IActionResult> Delete(int id)
        {
            
            await _blockService.DeleteAsync(id);
            return RedirectToAction("GetAllBlock");
        }

        [HttpGet]
        public async Task<IActionResult> GetBlockWithBulding()
        {
            var blockWithBuilding = await _blockService.GetBlockWithBuldingAsync();
            return View(blockWithBuilding);
        }


    }
}

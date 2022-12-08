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
        

        public BlockController(IBlockService blockService)
        {
            _blockService = blockService;
           
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blocks = await _blockService.GetAllAsync();
            return View(blocks);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            var buildings = await _blockService.GetById(Id);
            return View(buildings);
        }

        [HttpGet]
        public IActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(BlockDto blockDto)
        {
            var block = await _blockService.AddAsync(blockDto);
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
            _blockService.UpdateAsync(blockDto);
            return RedirectToAction("Getall");
        }

        [HttpGet]
        public async  Task<IActionResult> Delete(int id)
        {
            
            await _blockService.DeleteAsync(id);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> GetBlockWithBulding()
        {
           var blockWithBuilding =  await _blockService.GetBlockWithBuldingAsync();
           return View(blockWithBuilding);
        }


    }
}

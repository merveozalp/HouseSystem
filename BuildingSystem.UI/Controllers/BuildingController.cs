using AutoMapper;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Entities.Dtos;
using BuildingSystem.Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingSystem.UI.Controllers
{
    public class BuildingController : Controller
    {

        private readonly IBuildingService _buildingService;
        private readonly IBlockService _blockService;
        private readonly IMapper _mapper;


        public BuildingController(IBuildingService buildingService, IBlockService blockService, IMapper mapper)
        {
            _buildingService = buildingService;
            _blockService = blockService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBuildingByIdWithFlatAsync(int buildingId)
        {
            var buildingWithFlat = await _buildingService.GetBuildingByIdWithFlatAsync(buildingId);
            return View(buildingWithFlat);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBuilding()
        {
            var buildings = await _buildingService.GetAllAsync();
            return View(buildings);
        }

        
     

        [HttpGet]
        public async Task<IActionResult> AddBuilding ()
        {
            var blocks = await _blockService.GetAllAsync();
            ViewBag.Building = new SelectList(blocks, "Id", "BlockName");
            return View();
           
        }
        

        [HttpPost]
        public async Task<IActionResult> AddBuilding(BuildingDto buildingDto)
        {
            if (ModelState.IsValid)
            {
                var buildings = await _buildingService.AddAsync(buildingDto);
                return RedirectToAction("GetAllBuilding");
            }
            var block = await _blockService.GetAllAsync();
            ViewBag.blocks = new SelectList(block, "Id", "BlockName");
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdateBuilding(int id)
        {
            var building = await _buildingService.GetById(id);
            if (building == null) return RedirectToAction("GetAllBuilding");
            return View(building);
        }

        [HttpPost]
        public IActionResult UpdateBuilding(BuildingDto buildingDto)
        {
            _buildingService.UpdateAsync(buildingDto);
            return RedirectToAction("GetAllBuilding");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _buildingService.DeleteAsync(id);
            return RedirectToAction("GetAll");
        }
    }
}

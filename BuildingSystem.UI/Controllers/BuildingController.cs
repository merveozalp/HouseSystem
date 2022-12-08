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
        public async Task<IActionResult> GetAll()
        {
            var buildings = await _buildingService.GetAllAsync();
            return View(buildings);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            var buildings = await _buildingService.GetById(Id);
            return View(buildings);
        }

        [HttpGet]
        public async Task<IActionResult> Save ()
        {
            var blocks = await _blockService.GetAllAsync();
            ViewBag.School = new SelectList(blocks, "Id", "BlockName");
            return View();
           
        }
        

        [HttpPost]
        public async Task<IActionResult> Save(BuildingDto buildingDto)
        {
            if (ModelState.IsValid)
            {
                var buildings = await _buildingService.AddAsync(buildingDto);
                return RedirectToAction("GetAll");
            }
            var block = await _blockService.GetAllAsync();
            ViewBag.blocks = new SelectList(block, "Id", "BlockName");
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var building = await _buildingService.GetById(id);
            if (building == null) return RedirectToAction("GetAll");
            return View(building);
        }

        [HttpPost]
        public IActionResult Update(BuildingDto buildingDto)
        {
            _buildingService.UpdateAsync(buildingDto);
            return RedirectToAction("GetAll");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var buildings = await _buildingService.GetById(Id);
            await _buildingService.DeleteAsync(buildings);
            return RedirectToAction("GetAll");
        }
    }
}

using AutoMapper;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Entities.Dtos;
using BuildingSystem.Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingSystem.UI.Controllers
{
    public class BuildingController : Controller
    {

        private readonly IBuildingService _buildingService;
        private readonly IMapper _mapper;

        public BuildingController(IBuildingService buildingService, IMapper mapper)
        {
            _buildingService = buildingService;
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
            var buildingsDto = _mapper.Map<List<BuildingDto>>(buildings.ToList());
            return View(buildingsDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            var buildings = await _buildingService.GetById(Id);
            var buildingsDto = _mapper.Map<BuildingDto>(buildings);
            return View(buildingsDto);
        }

        [HttpGet]
        public IActionResult Save ()
        {
            return View();
        }
        

        [HttpPost]
        public async Task<IActionResult> Save(BuildingDto buildingDto)
        {
            var buildings = await _buildingService.AddAsync(_mapper.Map<Building>(buildingDto));
            var buildingsDto = _mapper.Map<BuildingDto>(buildings);
            return RedirectToAction("GetAll");
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
            _buildingService.UpdateAsync(_mapper.Map<Building>(buildingDto));
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

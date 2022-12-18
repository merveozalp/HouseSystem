using BuildingSystem.Business.Abstract;
using BuildingSystem.Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BuildingSystem.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BuildingController : Controller
    {
        private readonly IBuildingService _buildingService;
        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }
        public async Task<IActionResult> GetAllBuilding()
        {
            var buildings = await _buildingService.GetAllAsync();
            return View(buildings);
        }
        [HttpGet]
        public IActionResult AddBuilding()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBuilding(BuildingDto buildingDto)
        {

            var buildings = await _buildingService.AddAsync(buildingDto);
            return RedirectToAction("GetAllBuilding");

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
            _buildingService.Update(buildingDto);
            return RedirectToAction("GetAllBuilding");
        }
        [HttpGet]
        public IActionResult DeleteBuilding(int id)
        {
            _buildingService.Delete(id);
            return RedirectToAction("GetAllBuilding");
        }
       
    }
}

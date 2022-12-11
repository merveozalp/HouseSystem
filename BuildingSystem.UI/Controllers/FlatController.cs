using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.Concrete;
using BuildingSystem.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace BuildingSystem.UI.Controllers
{
    public class FlatController : Controller
    {
        private readonly IFlatService _flatService;
        private readonly IBuildingService _buildingService;
        private readonly IUserService _userService;
        private readonly IBlockService _blockService;

        public FlatController(IFlatService flatService, IBuildingService buildingService, IUserService userService)
        {
            _flatService = flatService;
            _buildingService = buildingService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var flats = await _flatService.GetAllFlats();
            return View(flats);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var flats = await _flatService.GetById(id);
            return View(flats);
        }

        [HttpGet]  // Block Alamıyorsun.
        public async  Task<IActionResult> Add()
        {

            var buildings = await _buildingService.GetAllAsync();
            ViewBag.Building = new SelectList(buildings, "Id", "BuildingName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(FlatCreateDto flatCreateDto)
        {
            if (ModelState.IsValid)
            {
                flatCreateDto.IsEmpty = true;
                var expenses = await _flatService.AddAsync(flatCreateDto);
                return RedirectToAction("GetAll");
            }
          

            var buildings = await _buildingService.GetAllAsync();
            ViewBag.Building = new SelectList(buildings, "Id", "BuildingName");
            return View(flatCreateDto);




        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var flat = await _flatService.GetById(id);
            var buildingDto = await _buildingService.GetAllAsync();
            var userDto = await _userService.GetAllAsync();
           
            var flatUpdateDto = new FlatUpdateDto()
            {
                Id = flat.Id,
                FlatNumber = flat.FlatNumber,
                IsEmpty = flat.IsEmpty,
                FlatType = flat.FlatType,
                Buildings = buildingDto,
                Users= userDto
               

            };
            return View(flatUpdateDto);
        }

        [HttpPost]
        public IActionResult Update(FlatUpdateDto flatUpdateDto)
        {
            if (!ModelState.IsValid) return View(flatUpdateDto);
            _flatService.UpdateAsync(flatUpdateDto);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            
            await _flatService.DeleteAsync(id);
            return RedirectToAction("GetAll");
        }
    }
}

using BuildingSystem.Business.Abstract;
using BuildingSystem.Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace BuildingSystem.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FlatController : Controller
    {
        private readonly IFlatService _flatService;
        private readonly IBuildingService _buildingService;
        private readonly IUserService _userService;

        public FlatController(IFlatService flatService, IBuildingService buildingService, IUserService userservice)
        {
            _flatService = flatService;
            _buildingService = buildingService;
            _userService = userservice;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllFlat()
        {
            var flats = await _flatService.GetAllFlatsWithRelation();
            return View(flats);
        }

        [HttpGet]
        public async Task<IActionResult> AddFlat()
        {
            var buildingDto = await _buildingService.GetAllAsync();
            ViewBag.Building = new SelectList(buildingDto, "Id", "BuildingName");
            var userDto = await _userService.GetAllAsync();
            ViewBag.User = new SelectList(userDto, "Id", "UserName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFlat(FlatCreateDto flatCreateDto)
        {
            if (!ModelState.IsValid)
            {
                var buildingDto = await _buildingService.GetAllAsync();
                ViewBag.Building = new SelectList(buildingDto, "Id", "BuildingName");
                var userDto = await _userService.GetAllAsync();
                ViewBag.User = new SelectList(userDto, "Id", "UserName");
                return View(flatCreateDto);
            }

            flatCreateDto.IsEmpty = true;
            await _flatService.AddAsync(flatCreateDto);
            return RedirectToAction("GetAllFlat");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateFlat(int id)
        {
            var flat = await _flatService.GetById(id);
            var flats = await _flatService.GetAllAsync();
            var buildingDto = await _buildingService.GetAllAsync();
            ViewBag.Building = new SelectList(buildingDto, "Id", "BuildingName");
            var userDto = await _userService.GetAllAsync();
            ViewBag.User = new SelectList(userDto, "Id", "UserName");

            var flatUpdateDto = new FlatUpdateDto()
            {
                Id = flat.Id,
                FloorNumber = flat.FloorNumber,
                IsOwner = flat.IsOwner,
                IsEmpty = flat.IsEmpty,
                FlatType = flat.FlatType,
                FlatNumber = flat.FlatNumber,



            };
            return View(flatUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFlat(FlatUpdateDto flatUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                var buildingDto = await _buildingService.GetAllAsync();
                ViewBag.Building = new SelectList(buildingDto, "Id", "BuildingName");
                var userDto = await _userService.GetAllAsync();
                ViewBag.User = new SelectList(userDto, "Id", "UserName");
                return View(flatUpdateDto);
            }
            _flatService.UpdateAsync(flatUpdateDto);
            return RedirectToAction("GetAllFlat");
        }
        [HttpGet]
        public IActionResult DeleteFlat(int id)
        {

            _flatService.DeleteAsync(id);
            return RedirectToAction("GetAllFlat");
        }
       
    }
}

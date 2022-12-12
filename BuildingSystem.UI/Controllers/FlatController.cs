using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.Concrete;
using BuildingSystem.DataAccess.Context;
using BuildingSystem.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Mozilla;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingSystem.UI.Controllers
{
    public class FlatController : Controller
    {
        private readonly IFlatService _flatService;
        private readonly IBuildingService _buildingService;
        private readonly IUserService _userService;
        private readonly IBlockService _blockService;
        private readonly IFlatTypeService _flatTypeService;
       


        public FlatController(IFlatService flatService, IBuildingService buildingService, IUserService userService, IFlatTypeService flatTypeService)
        {
            _flatService = flatService;
            _buildingService = buildingService;
            _userService = userService;
            _flatTypeService = flatTypeService;
            
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
            
            var flatTypes = await _flatTypeService.GetAllAsync();
            ViewBag.FlatTypes = new SelectList(flatTypes, "Id", "FlatTypeName");
            var buildings = await _buildingService.GetAllAsync();
            ViewBag.Building = new SelectList(buildings, "Id", "BuildingName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(FlatCreateDto flatCreateDto) // Blok Seçebilmeli
        {
            if (ModelState.IsValid)
            {
                flatCreateDto.IsEmpty = true;
                var expenses = await _flatService.AddAsync(flatCreateDto);
                return RedirectToAction("GetAll");
            }

            var flatTypes = await _flatTypeService.GetAllAsync();
            ViewBag.FlatTypes = new SelectList(flatTypes, "Id", "FlatTypeName");

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

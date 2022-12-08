using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.Concrete;
using BuildingSystem.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BuildingSystem.UI.Controllers
{
    public class FlatController : Controller
    {
        private readonly IFlatService _flatService;

        public FlatController(IFlatService flatService)
        {
            _flatService = flatService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var flats = await _flatService.GetAllAsync();
            return View(flats);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var flats = await _flatService.GetById(id);
            return View(flats);
        }

        [HttpGet]
        public  IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(FlatCreateDto flatCreateDto)
        {
            if (!ModelState.IsValid) return View(flatCreateDto);
            flatCreateDto.IsEmpty = false;
            var expenses = await _flatService.AddAsync(flatCreateDto);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var flats = await _flatService.GetById(id);
            if (flats is null) return RedirectToAction("GetAll");
            return View(flats);
        }

        [HttpPost]
        public IActionResult Update(FlatUpdateDto flatUpdateDto)
        {
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

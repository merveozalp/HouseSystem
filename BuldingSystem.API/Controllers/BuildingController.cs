using AutoMapper;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.Concrete;
using BuildingSystem.Entities.Dtos;
using BuildingSystem.Entities.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuldingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;
        private readonly IMapper _mapper;
      

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
            
        }

        [HttpGet("[action]/{buildingId}")]
        public async  Task<IActionResult> GetBuildingByIdWithFlatAsync(int buildingId)
        {
           var buildingWithFlat= await  _buildingService.GetBuildingByIdWithFlatAsync(buildingId);
            return Ok(buildingWithFlat);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var buildings = await _buildingService.GetAllAsync();
            var buildingsDto = _mapper.Map<List<BuildingDto>>(buildings.ToList());
            return Ok(buildingsDto);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var buildings = await _buildingService.GetById(Id);
            var buildingsDto = _mapper.Map<BuildingDto>(buildings);
            return Ok(buildingsDto);
        }

        [HttpPost]
        public async Task<IActionResult> Save(BuildingDto buildingDto)
        {
            var buildings = await _buildingService.AddAsync(_mapper.Map<Building>(buildingDto)); 
            var buildingsDto = _mapper.Map<BuildingDto>(buildings);
            return Ok(buildingsDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(BuildingDto buildingDto)
        {
            await _buildingService.UpdateAsync(_mapper.Map<Building>(buildingDto));
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var buildings = await _buildingService.GetById(Id);
            await _buildingService.DeleteAsync(buildings);
            return Ok();
        }


    }
}

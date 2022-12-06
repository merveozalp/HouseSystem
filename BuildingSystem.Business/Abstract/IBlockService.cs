using BuildingSystem.Entities.Dtos;
using BuildingSystem.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Abstract
{
    public interface IBlockService:IService<Block>
    {
        
        Task<List<BlockWithBuildingDto>> GetBlockWithBuldingAsync();

        //Task<Block> GetsingleBlocByIdkWithBulding(int blockId);
    }
}

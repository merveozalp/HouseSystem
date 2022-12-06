using BuildingSystem.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.DataAccess.Abstract
{
    public interface IBlockRepository:IGenericRepository<Block>
    {
        Task<List<Block>> GetBlockWithBuldingAsync();
        Task<Block> GetsingleBlocByIdkWithBulding(int blockId);
    }
}

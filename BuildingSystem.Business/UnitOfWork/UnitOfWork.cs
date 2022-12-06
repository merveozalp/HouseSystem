using BuildingSystem.DataAccess.Context;
using System.Threading.Tasks;

namespace BuildingSystem.Business.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applictionDbContext;

        public UnitOfWork(ApplicationDbContext applictionDbContext)
        {
            _applictionDbContext = applictionDbContext;
        }

        public void Commit()
        {
            _applictionDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
           await  _applictionDbContext.SaveChangesAsync();
        }
    }
}

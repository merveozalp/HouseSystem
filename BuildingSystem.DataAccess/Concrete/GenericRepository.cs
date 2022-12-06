using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        // Serice bazında özel metotlar yazmak istersem miraz aldıım classların erişebilmesi için protected yaptım.
        protected readonly ApplicationDbContext _db;
        private readonly DbSet<T> _dbSet;

        public GenericRepository( ApplicationDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
           
        }

        public async Task AddAsync(T entity)
        {
           await _dbSet.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }
       
        public void Delete(T entity)
        {
            // Memorydeki entity state'ine Deleted atıyoruz. Ağır bir metod değil bundan dolayı asenkron değil.
           _dbSet.Remove(entity);
        }

        public  IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();    
            // Asnotracking dememizin sebebi memory'e almamasını sağlıyoruz. Asnotracking demezsek veritabanında çeker ve izler.
            // Queryable dedik çünkü eğer ki orderby vs demek istersek onları dedikten sonra db'ye yansısın.
        }

        public async Task<T> GetById(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}

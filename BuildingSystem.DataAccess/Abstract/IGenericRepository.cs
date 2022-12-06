using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BuildingSystem.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int Id);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T,bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T,bool>> expression);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
       // T SingleOrDefault(Expression<Func<T, bool>> predicate);
        



    }
}

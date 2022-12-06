using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Abstract
{
    public interface IService<T> where T:class
    {
        Task<T> GetById(int Id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression); // Tolist veya tolistAsync çağırdığım zaman veritabanına yansısın istiyorum işlem.
                                                                   // o yüzden Queryable dedim.
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        // repoda Dbcontext EfCore async metodları yok. (Update,delete)
        // fakat service katmanında artık db'ye yansıtacağımız için savechange kullanacağımız için Task yaptık.
    }
}

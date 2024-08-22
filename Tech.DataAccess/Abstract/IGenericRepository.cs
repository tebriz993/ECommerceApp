using System.Linq.Expressions;

namespace Tech.DataAccess.Abstract;

public interface IGenericRepository<T> where T: class,new()
{
    Task<IEnumerable<T>> GetAllAsync(bool tracking = true);
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> expression);
    Task<bool> AddAsync(T entity);
    Task SaveChangesAsync();
    bool Update(T entity);
    bool Remove(T entity);
}

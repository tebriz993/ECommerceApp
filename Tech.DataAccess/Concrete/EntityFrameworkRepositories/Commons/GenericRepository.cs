using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;
using Tech.DataAccess.Abstract;
using Tech.DataAccess.EntityFrameworks.Contexts;
using Tech.Entity.Concrete.Products;

namespace Tech.DataAccess.Concrete.EntityFrameworkRepositories.Commons;

public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
{
    private readonly TechContext _dbContext;

    public DbSet<T> TableEntity => _dbContext.Set<T>();
    public GenericRepository(TechContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> AddAsync(T entity)
    {
        var addedState = await TableEntity.AddAsync(entity);
        return addedState.State == EntityState.Added;
    }

    public async Task<IEnumerable<T>> GetAllAsync(bool tracking = true)
    {
        if (tracking is false)
        {
            return await TableEntity.AsNoTracking().ToListAsync();
        }
        return await TableEntity.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id) => await TableEntity.FindAsync(id);

    public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> expression)
        => await TableEntity.Where(expression).ToListAsync();

    public bool Remove(T entity)
    {
        var removed = TableEntity.Remove(entity);
        return removed.State == EntityState.Deleted;
    }

    public bool Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        return true;
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}

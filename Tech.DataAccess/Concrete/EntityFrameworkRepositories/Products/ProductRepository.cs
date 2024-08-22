using Microsoft.EntityFrameworkCore;
using Tech.DataAccess.Abstract.Products;
using Tech.DataAccess.Concrete.EntityFrameworkRepositories.Commons;
using Tech.DataAccess.EntityFrameworks.Contexts;
using Tech.Entity.Concrete.Products;

namespace Tech.DataAccess.Concrete.EntityFrameworkRepositories.Products;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(TechContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await TableEntity.Include(x=>x.Category).ToListAsync();
    }
}

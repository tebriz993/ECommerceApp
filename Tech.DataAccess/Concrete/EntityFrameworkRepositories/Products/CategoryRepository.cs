using Tech.DataAccess.Abstract.Products;
using Tech.DataAccess.Concrete.EntityFrameworkRepositories.Commons;
using Tech.DataAccess.EntityFrameworks.Contexts;
using Tech.Entity.Concrete.Products;

namespace Tech.DataAccess.Concrete.EntityFrameworkRepositories.Products;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(TechContext dbContext) : base(dbContext)
    {
    }
}

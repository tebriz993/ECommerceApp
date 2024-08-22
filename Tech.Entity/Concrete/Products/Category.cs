using Tech.Entity.Concrete.Common;

namespace Tech.Entity.Concrete.Products;

public class Category:BaseEntity
{
    public Category()
    {
        Products = new HashSet<Product>();
    }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<Product> Products { get; set; }
}

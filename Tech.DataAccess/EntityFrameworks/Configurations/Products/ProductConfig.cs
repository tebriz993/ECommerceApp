using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tech.DataAccess.EntityFrameworks.Configurations.Common;
using Tech.Entity.Concrete.Common;
using Tech.Entity.Concrete.Products;

namespace Tech.DataAccess.EntityFrameworks.Configurations.Products;

public class ProductConfig:BaseConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.Description)
          .IsRequired(false)
          .HasColumnType("nText");

        builder.HasOne(x=>x.Category)
            .WithMany(x=>x.Products)
            .HasForeignKey(x=>x.CategoryId);


        builder.HasMany(x => x.Orders)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);
    }
}

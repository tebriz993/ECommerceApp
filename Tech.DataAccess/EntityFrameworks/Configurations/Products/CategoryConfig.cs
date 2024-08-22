using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tech.DataAccess.EntityFrameworks.Configurations.Common;
using Tech.Entity.Concrete.Products;

namespace Tech.DataAccess.EntityFrameworks.Configurations.Products;

public class CategoryConfig:BaseConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Description)
            .IsRequired(false)
            .HasColumnType("nText");

    }
}

using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.FluentApiConfigurations;
public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
  

    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");
        builder.HasKey(p=>p.Id);
        builder.Property(p=>p.ProductName)
                .HasMaxLength(160)
                .HasColumnName("Title");
        

    }
}


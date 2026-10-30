using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestApiEshop.Domain.Entities;
using RestApiEshop.Infrastructure.Persistence.Seed;

namespace RestApiEshop.Infrastructure.Persistence.Configurations
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("Products");

			builder.HasKey(p => p.Id);

			builder.Property(p => p.Name)
				.IsRequired()
				.HasMaxLength(Product.NameMaxLength);

			builder.Property(p => p.ImgUri)
				.IsRequired()
				.HasMaxLength(Product.ImgUriMaxLength);

			builder.Property(p => p.Price)
				.HasPrecision(18, 2);

			builder.Property(p => p.Description)
				.HasMaxLength(Product.DescriptionMaxLength);

			builder.HasData(ProductSeedData.Products);
		}
	}
}

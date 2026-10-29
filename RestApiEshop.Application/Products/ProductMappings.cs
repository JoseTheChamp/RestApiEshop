using RestApiEshop.Domain.Entities;

namespace RestApiEshop.Application.Products
{
	internal static class ProductMappings
	{
		public static ProductDto ToDto(this Product product)
		{
			return new ProductDto(product.Id, product.Name, product.ImgUri, product.Price, product.Description);
		}
	}
}

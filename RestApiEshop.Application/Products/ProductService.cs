using RestApiEshop.Domain.Entities;

namespace RestApiEshop.Application.Products
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task<IReadOnlyList<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			IReadOnlyList<Product> products = await _productRepository.GetAllAsync(cancellationToken);

			return products.Select(p => p.ToDto()).ToList();
		}

		public async Task<ProductDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
		{
			Product? product = await _productRepository.GetByIdAsync(id, cancellationToken);

			return product?.ToDto();
		}
	}
}

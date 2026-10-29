using Microsoft.Extensions.Logging;
using RestApiEshop.Domain.Entities;

namespace RestApiEshop.Application.Products
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;
		private readonly ILogger<ProductService> _logger;

		public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
		{
			_productRepository = productRepository;
			_logger = logger;
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

		public async Task<ProductDto?> UpdateDescriptionAsync(int id, string? description, CancellationToken cancellationToken = default)
		{
			Product? product = await _productRepository.GetByIdAsync(id, cancellationToken);
			if (product is null)
			{
				return null;
			}

			product.Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
			await _productRepository.UpdateAsync(product, cancellationToken);

			_logger.LogInformation("Description of product {ProductId} was updated", id);

			return product.ToDto();
		}
	}
}

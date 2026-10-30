using RestApiEshop.Application.Products;
using RestApiEshop.Domain.Entities;

namespace RestApiEshop.Infrastructure.Mock
{
	public class MockProductRepository : IProductRepository
	{
		private readonly List<Product> _products;
		private readonly Lock _lock = new();

		public MockProductRepository(IEnumerable<Product> products)
		{
			_products = products.OrderBy(p => p.Id).Select(Copy).ToList();
		}

		public Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			lock (_lock)
			{
				return Task.FromResult<IReadOnlyList<Product>>(_products.Select(Copy).ToList());
			}
		}

		public Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
		{
			lock (_lock)
			{
				Product? product = _products.FirstOrDefault(p => p.Id == id);

				return Task.FromResult(product is null ? null : Copy(product));
			}
		}

		public Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
		{
			lock (_lock)
			{
				int index = _products.FindIndex(p => p.Id == product.Id);
				if (index == -1)
				{
					throw new InvalidOperationException($"Product with id {product.Id} does not exist.");
				}

				_products[index] = Copy(product);
			}

			return Task.CompletedTask;
		}

		// Callers always work with copies, so a change is stored only when UpdateAsync is called - same as with the database
		private static Product Copy(Product product)
		{
			return new Product
			{
				Id = product.Id,
				Name = product.Name,
				ImgUri = product.ImgUri,
				Price = product.Price,
				Description = product.Description
			};
		}
	}
}

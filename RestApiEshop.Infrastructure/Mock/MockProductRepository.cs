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
			_products = products.OrderBy(p => p.Id).ToList();
		}

		public Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			lock (_lock)
			{
				return Task.FromResult<IReadOnlyList<Product>>(_products.ToList());
			}
		}

		public Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
		{
			lock (_lock)
			{
				return Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
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

				_products[index] = product;
			}

			return Task.CompletedTask;
		}
	}
}

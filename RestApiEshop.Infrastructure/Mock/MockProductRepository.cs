using RestApiEshop.Application.Products;
using RestApiEshop.Domain.Entities;

namespace RestApiEshop.Infrastructure.Mock
{
	public class MockProductRepository : IProductRepository
	{
		private readonly List<Product> _products;

		public MockProductRepository(IEnumerable<Product> products)
		{
			_products = products.OrderBy(p => p.Id).ToList();
		}

		public Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			return Task.FromResult<IReadOnlyList<Product>>(_products.ToList());
		}

		public Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
		{
			return Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
		}
	}
}

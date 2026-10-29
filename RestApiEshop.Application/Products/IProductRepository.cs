using RestApiEshop.Domain.Entities;

namespace RestApiEshop.Application.Products
{
	public interface IProductRepository
	{
		Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default);

		Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
	}
}

using RestApiEshop.Application.Common;

namespace RestApiEshop.Application.Products
{
	public interface IProductService
	{
		Task<IReadOnlyList<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default);

		Task<PagedResult<ProductDto>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);

		Task<ProductDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

		Task<ProductDto?> UpdateDescriptionAsync(int id, string? description, CancellationToken cancellationToken = default);
	}
}

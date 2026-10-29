namespace RestApiEshop.Application.Products
{
	public interface IProductService
	{
		Task<IReadOnlyList<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default);

		Task<ProductDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
	}
}

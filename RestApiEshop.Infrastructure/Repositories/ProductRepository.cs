using Microsoft.EntityFrameworkCore;
using RestApiEshop.Application.Products;
using RestApiEshop.Domain.Entities;
using RestApiEshop.Infrastructure.Persistence;

namespace RestApiEshop.Infrastructure.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly EshopDbContext _context;

		public ProductRepository(EshopDbContext context)
		{
			_context = context;
		}

		public async Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			return await _context.Products
				.AsNoTracking()
				.OrderBy(p => p.Id)
				.ToListAsync(cancellationToken);
		}

		public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
		{
			return await _context.Products.FindAsync([id], cancellationToken);
		}

		public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
		{
			if (_context.Entry(product).State == EntityState.Detached)
			{
				_context.Products.Update(product);
			}

			await _context.SaveChangesAsync(cancellationToken);
		}
	}
}

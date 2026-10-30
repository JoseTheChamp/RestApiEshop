using Microsoft.EntityFrameworkCore;
using RestApiEshop.Domain.Entities;

namespace RestApiEshop.Infrastructure.Persistence
{
	public class EshopDbContext : DbContext
	{
		public EshopDbContext(DbContextOptions<EshopDbContext> options) : base(options)
		{
		}

		public DbSet<Product> Products => Set<Product>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(EshopDbContext).Assembly);
		}
	}
}

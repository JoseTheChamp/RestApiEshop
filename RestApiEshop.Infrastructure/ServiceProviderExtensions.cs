using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestApiEshop.Infrastructure.Persistence;

namespace RestApiEshop.Infrastructure
{
	public static class ServiceProviderExtensions
	{
		public static async Task ApplyMigrationsAsync(this IServiceProvider serviceProvider, CancellationToken cancellationToken = default)
		{
			using IServiceScope scope = serviceProvider.CreateScope();

			EshopDbContext context = scope.ServiceProvider.GetRequiredService<EshopDbContext>();
			await context.Database.MigrateAsync(cancellationToken);
		}
	}
}

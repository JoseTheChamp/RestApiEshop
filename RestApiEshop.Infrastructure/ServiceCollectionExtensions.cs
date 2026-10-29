using Microsoft.Extensions.DependencyInjection;
using RestApiEshop.Application.Products;
using RestApiEshop.Infrastructure.Mock;

namespace RestApiEshop.Infrastructure
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddSingleton<IProductRepository>(new MockProductRepository(MockProductData.GetProducts()));

			return services;
		}
	}
}

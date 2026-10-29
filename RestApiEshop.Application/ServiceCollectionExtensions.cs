using Microsoft.Extensions.DependencyInjection;
using RestApiEshop.Application.Products;

namespace RestApiEshop.Application
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddScoped<IProductService, ProductService>();

			return services;
		}
	}
}

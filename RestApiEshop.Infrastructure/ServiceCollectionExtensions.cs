using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestApiEshop.Application.Products;
using RestApiEshop.Infrastructure.Persistence;
using RestApiEshop.Infrastructure.Repositories;

namespace RestApiEshop.Infrastructure
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<EshopDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("EshopDatabase")));

			services.AddScoped<IProductRepository, ProductRepository>();

			return services;
		}
	}
}

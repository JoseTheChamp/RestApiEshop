using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace RestApiEshop.Tests.Api
{
	// Runs the whole API in memory on top of the mock data, so the tests don't need a database
	public class MockDataApiFactory : WebApplicationFactory<Program>
	{
		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			builder.UseSetting("UseMockData", "true");
		}
	}
}

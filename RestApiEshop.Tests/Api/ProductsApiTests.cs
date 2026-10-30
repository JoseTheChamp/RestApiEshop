using System.Net;
using System.Net.Http.Json;
using RestApiEshop.Application.Common;
using RestApiEshop.Application.Products;

namespace RestApiEshop.Tests.Api
{
	public class ProductsApiTests : IClassFixture<MockDataApiFactory>
	{
		private readonly HttpClient _client;

		public ProductsApiTests(MockDataApiFactory factory)
		{
			_client = factory.CreateClient();
		}

		[Fact]
		public async Task GetProducts_V1_ReturnsAllProducts()
		{
			List<ProductDto>? products = await _client.GetFromJsonAsync<List<ProductDto>>("/api/v1/products");

			Assert.NotNull(products);
			Assert.Equal(12, products.Count);
		}

		[Fact]
		public async Task GetProducts_V2_WithoutPaging_ReturnsFirstPageOfTen()
		{
			PagedResult<ProductDto>? page = await _client.GetFromJsonAsync<PagedResult<ProductDto>>("/api/v2/products");

			Assert.NotNull(page);
			Assert.Equal(1, page.PageNumber);
			Assert.Equal(10, page.PageSize);
			Assert.Equal(10, page.Items.Count);
			Assert.Equal(12, page.TotalCount);
			Assert.Equal(2, page.TotalPages);
		}

		[Fact]
		public async Task GetProducts_V2_ReturnsRequestedPage()
		{
			PagedResult<ProductDto>? page = await _client.GetFromJsonAsync<PagedResult<ProductDto>>("/api/v2/products?pageNumber=2&pageSize=5");

			Assert.NotNull(page);
			Assert.Equal(new[] { 6, 7, 8, 9, 10 }, page.Items.Select(p => p.Id));
		}

		[Theory]
		[InlineData("pageNumber=0")]
		[InlineData("pageSize=0")]
		[InlineData("pageSize=101")]
		[InlineData("pageNumber=abc")]
		public async Task GetProducts_V2_InvalidPaging_ReturnsBadRequest(string query)
		{
			HttpResponseMessage response = await _client.GetAsync($"/api/v2/products?{query}");

			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
		}

		[Fact]
		public async Task GetProducts_UnsupportedVersion_ReturnsNotFound()
		{
			HttpResponseMessage response = await _client.GetAsync("/api/v3/products");

			Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
		}

		[Theory]
		[InlineData("v1")]
		[InlineData("v2")]
		public async Task GetProduct_ExistingId_ReturnsProduct(string version)
		{
			ProductDto? product = await _client.GetFromJsonAsync<ProductDto>($"/api/{version}/products/2");

			Assert.NotNull(product);
			Assert.Equal("Mechanical Keyboard", product.Name);
		}

		[Fact]
		public async Task GetProduct_UnknownId_ReturnsNotFoundProblem()
		{
			HttpResponseMessage response = await _client.GetAsync("/api/v1/products/999");

			Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
			Assert.Equal("application/problem+json", response.Content.Headers.ContentType?.MediaType);
		}

		[Fact]
		public async Task UpdateProductDescription_UpdatesProduct()
		{
			HttpResponseMessage response = await _client.PatchAsJsonAsync("/api/v1/products/5", new { description = "Updated in test" });

			Assert.Equal(HttpStatusCode.OK, response.StatusCode);

			ProductDto? product = await _client.GetFromJsonAsync<ProductDto>("/api/v1/products/5");
			Assert.Equal("Updated in test", product!.Description);
		}

		[Fact]
		public async Task UpdateProductDescription_TooLongDescription_ReturnsBadRequest()
		{
			HttpResponseMessage response = await _client.PatchAsJsonAsync("/api/v1/products/6", new { description = new string('a', 4001) });

			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
		}

		[Fact]
		public async Task UpdateProductDescription_MissingDescription_ReturnsBadRequest()
		{
			HttpResponseMessage response = await _client.PatchAsJsonAsync("/api/v1/products/6", new { });

			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
		}

		[Fact]
		public async Task UpdateProductDescription_UnknownId_ReturnsNotFound()
		{
			HttpResponseMessage response = await _client.PatchAsJsonAsync("/api/v1/products/999", new { description = "Updated in test" });

			Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
		}

		[Theory]
		[InlineData("v1")]
		[InlineData("v2")]
		public async Task OpenApiDocument_IsAvailableForEachVersion(string version)
		{
			HttpResponseMessage response = await _client.GetAsync($"/openapi/{version}.json");

			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}
	}
}

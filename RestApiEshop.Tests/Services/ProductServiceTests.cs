using Microsoft.Extensions.Logging.Abstractions;
using RestApiEshop.Application.Products;
using RestApiEshop.Domain.Entities;
using RestApiEshop.Infrastructure.Mock;

namespace RestApiEshop.Tests.Services
{
	public class ProductServiceTests
	{
		private readonly MockProductRepository _repository;
		private readonly ProductService _service;

		public ProductServiceTests()
		{
			_repository = new MockProductRepository(MockProductData.GetProducts());
			_service = new ProductService(_repository, NullLogger<ProductService>.Instance);
		}

		[Fact]
		public async Task GetAllAsync_ReturnsAllProductsOrderedById()
		{
			IReadOnlyList<ProductDto> products = await _service.GetAllAsync();

			Assert.Equal(Enumerable.Range(1, 12), products.Select(p => p.Id));
		}

		[Fact]
		public async Task GetByIdAsync_ExistingProduct_ReturnsProduct()
		{
			ProductDto? product = await _service.GetByIdAsync(3);

			Assert.NotNull(product);
			Assert.Equal(3, product.Id);
			Assert.Equal("27\" Monitor", product.Name);
			Assert.Equal(7800m, product.Price);
		}

		[Fact]
		public async Task GetByIdAsync_UnknownProduct_ReturnsNull()
		{
			ProductDto? product = await _service.GetByIdAsync(999);

			Assert.Null(product);
		}

		[Fact]
		public async Task UpdateDescriptionAsync_ExistingProduct_UpdatesDescription()
		{
			ProductDto? product = await _service.UpdateDescriptionAsync(1, "New description");

			Assert.NotNull(product);
			Assert.Equal("New description", product.Description);

			Product? storedProduct = await _repository.GetByIdAsync(1);
			Assert.Equal("New description", storedProduct!.Description);
		}

		[Fact]
		public async Task UpdateDescriptionAsync_DescriptionWithWhitespace_IsTrimmed()
		{
			ProductDto? product = await _service.UpdateDescriptionAsync(1, "  New description  ");

			Assert.Equal("New description", product!.Description);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("   ")]
		public async Task UpdateDescriptionAsync_EmptyDescription_RemovesDescription(string? description)
		{
			ProductDto? product = await _service.UpdateDescriptionAsync(1, description);

			Assert.NotNull(product);
			Assert.Null(product.Description);
		}

		[Fact]
		public async Task UpdateDescriptionAsync_UnknownProduct_ReturnsNull()
		{
			ProductDto? product = await _service.UpdateDescriptionAsync(999, "New description");

			Assert.Null(product);
		}
	}
}

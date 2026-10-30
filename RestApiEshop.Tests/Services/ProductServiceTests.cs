using Microsoft.Extensions.Logging.Abstractions;
using RestApiEshop.Application.Common;
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
		public async Task GetPagedAsync_ReturnsRequestedPage()
		{
			PagedResult<ProductDto> page = await _service.GetPagedAsync(pageNumber: 2, pageSize: 5);

			Assert.Equal(new[] { 6, 7, 8, 9, 10 }, page.Items.Select(p => p.Id));
			Assert.Equal(2, page.PageNumber);
			Assert.Equal(5, page.PageSize);
			Assert.Equal(12, page.TotalCount);
			Assert.Equal(3, page.TotalPages);
		}

		[Fact]
		public async Task GetPagedAsync_LastPage_ReturnsRemainingProducts()
		{
			PagedResult<ProductDto> page = await _service.GetPagedAsync(pageNumber: 2, pageSize: 10);

			Assert.Equal(new[] { 11, 12 }, page.Items.Select(p => p.Id));
			Assert.Equal(2, page.TotalPages);
		}

		[Fact]
		public async Task GetPagedAsync_PageAfterLastPage_ReturnsNoProducts()
		{
			PagedResult<ProductDto> page = await _service.GetPagedAsync(pageNumber: 5, pageSize: 10);

			Assert.Empty(page.Items);
			Assert.Equal(12, page.TotalCount);
		}

		[Fact]
		public async Task GetPagedAsync_NoProducts_ReturnsEmptyPage()
		{
			ProductService service = new(new MockProductRepository([]), NullLogger<ProductService>.Instance);

			PagedResult<ProductDto> page = await service.GetPagedAsync(pageNumber: 1, pageSize: 10);

			Assert.Empty(page.Items);
			Assert.Equal(0, page.TotalCount);
			Assert.Equal(0, page.TotalPages);
		}

		[Theory]
		[InlineData(0, 10)]
		[InlineData(1, 0)]
		[InlineData(-1, -1)]
		public async Task GetPagedAsync_InvalidPaging_Throws(int pageNumber, int pageSize)
		{
			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _service.GetPagedAsync(pageNumber, pageSize));
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

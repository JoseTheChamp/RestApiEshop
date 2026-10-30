using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using RestApiEshop.Application.Products;
using RestApiEshop.Controllers;
using RestApiEshop.Infrastructure.Mock;
using RestApiEshop.Models;

namespace RestApiEshop.Tests.Controllers
{
	public class ProductsControllerTests
	{
		private readonly ProductsController _controller;

		public ProductsControllerTests()
		{
			MockProductRepository repository = new(MockProductData.GetProducts());
			ProductService service = new(repository, NullLogger<ProductService>.Instance);

			_controller = new ProductsController(service);
		}

		[Fact]
		public async Task GetProducts_ReturnsOkWithAllProducts()
		{
			ActionResult<IReadOnlyList<ProductDto>> result = await _controller.GetProducts(CancellationToken.None);

			OkObjectResult okResult = Assert.IsType<OkObjectResult>(result.Result);
			IReadOnlyList<ProductDto> products = Assert.IsAssignableFrom<IReadOnlyList<ProductDto>>(okResult.Value);
			Assert.Equal(12, products.Count);
		}

		[Fact]
		public async Task GetProduct_ExistingId_ReturnsOkWithProduct()
		{
			ActionResult<ProductDto> result = await _controller.GetProduct(2, CancellationToken.None);

			OkObjectResult okResult = Assert.IsType<OkObjectResult>(result.Result);
			ProductDto product = Assert.IsType<ProductDto>(okResult.Value);
			Assert.Equal("Mechanical Keyboard", product.Name);
		}

		[Fact]
		public async Task GetProduct_UnknownId_ReturnsNotFound()
		{
			ActionResult<ProductDto> result = await _controller.GetProduct(999, CancellationToken.None);

			Assert.IsType<NotFoundResult>(result.Result);
		}

		[Fact]
		public async Task UpdateProductDescription_ExistingId_ReturnsOkWithUpdatedProduct()
		{
			UpdateProductDescriptionRequest request = new() { Description = "Updated description" };

			ActionResult<ProductDto> result = await _controller.UpdateProductDescription(4, request, CancellationToken.None);

			OkObjectResult okResult = Assert.IsType<OkObjectResult>(result.Result);
			ProductDto product = Assert.IsType<ProductDto>(okResult.Value);
			Assert.Equal(4, product.Id);
			Assert.Equal("Updated description", product.Description);
		}

		[Fact]
		public async Task UpdateProductDescription_UnknownId_ReturnsNotFound()
		{
			UpdateProductDescriptionRequest request = new() { Description = "Updated description" };

			ActionResult<ProductDto> result = await _controller.UpdateProductDescription(9999, request, CancellationToken.None);

			Assert.IsType<NotFoundResult>(result.Result);
		}
	}
}

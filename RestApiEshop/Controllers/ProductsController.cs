using System.ComponentModel.DataAnnotations;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestApiEshop.Application.Common;
using RestApiEshop.Application.Products;
using RestApiEshop.Models;

namespace RestApiEshop.Controllers
{
	[ApiController]
	[ApiVersion("1.0")]
	[ApiVersion("2.0")]
	[Route("api/v{version:apiVersion}/products")]
	public class ProductsController : ControllerBase
	{
		private const int DefaultPageSize = 10;
		private const int MaxPageSize = 100;

		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		[MapToApiVersion("1.0")]
		public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts(CancellationToken cancellationToken)
		{
			IReadOnlyList<ProductDto> products = await _productService.GetAllAsync(cancellationToken);

			return Ok(products);
		}

		[HttpGet]
		[MapToApiVersion("2.0")]
		public async Task<ActionResult<PagedResult<ProductDto>>> GetProductsPaged(
			[FromQuery, Range(1, int.MaxValue)] int pageNumber = 1,
			[FromQuery, Range(1, MaxPageSize)] int pageSize = DefaultPageSize,
			CancellationToken cancellationToken = default)
		{
			PagedResult<ProductDto> page = await _productService.GetPagedAsync(pageNumber, pageSize, cancellationToken);

			return Ok(page);
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<ProductDto>> GetProduct(int id, CancellationToken cancellationToken)
		{
			ProductDto? product = await _productService.GetByIdAsync(id, cancellationToken);
			if (product is null)
			{
				return NotFound();
			}

			return Ok(product);
		}

		[HttpPatch("{id:int}")]
		public async Task<ActionResult<ProductDto>> UpdateProductDescription(int id, UpdateProductDescriptionRequest request, CancellationToken cancellationToken)
		{
			ProductDto? product = await _productService.UpdateDescriptionAsync(id, request.Description, cancellationToken);
			if (product is null)
			{
				return NotFound();
			}

			return Ok(product);
		}
	}
}

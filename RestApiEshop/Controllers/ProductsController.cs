using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
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

		/// <summary>
		/// Returns all products.
		/// </summary>
		/// <response code="200">All products of the eshop.</response>
		[HttpGet]
		[MapToApiVersion("1.0")]
		[ProducesResponseType<IReadOnlyList<ProductDto>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
		public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts(CancellationToken cancellationToken)
		{
			IReadOnlyList<ProductDto> products = await _productService.GetAllAsync(cancellationToken);

			return Ok(products);
		}

		/// <summary>
		/// Returns one page of products.
		/// </summary>
		/// <param name="pageNumber">Page to return, starting at 1.</param>
		/// <param name="pageSize">Number of products on a page (max 100).</param>
		/// <response code="200">Requested page of products.</response>
		/// <response code="400">Page number or page size is out of range.</response>
		[HttpGet]
		[MapToApiVersion("2.0")]
		[ProducesResponseType<PagedResult<ProductDto>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
		[ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.ProblemJson)]
		public async Task<ActionResult<PagedResult<ProductDto>>> GetProductsPaged(
			[FromQuery, Range(1, int.MaxValue)] int pageNumber = 1,
			[FromQuery, Range(1, MaxPageSize)] int pageSize = DefaultPageSize,
			CancellationToken cancellationToken = default)
		{
			PagedResult<ProductDto> page = await _productService.GetPagedAsync(pageNumber, pageSize, cancellationToken);

			return Ok(page);
		}

		/// <summary>
		/// Returns the product with the given id.
		/// </summary>
		/// <param name="id">Id of the product.</param>
		/// <response code="200">The product.</response>
		/// <response code="404">Product with the given id does not exist.</response>
		[HttpGet("{id:int}")]
		[ProducesResponseType<ProductDto>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
		[ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound, MediaTypeNames.Application.ProblemJson)]
		public async Task<ActionResult<ProductDto>> GetProduct(int id, CancellationToken cancellationToken)
		{
			ProductDto? product = await _productService.GetByIdAsync(id, cancellationToken);
			if (product is null)
			{
				return NotFound();
			}

			return Ok(product);
		}

		/// <summary>
		/// Updates the description of the product with the given id.
		/// </summary>
		/// <param name="id">Id of the product.</param>
		/// <param name="request">The new description.</param>
		/// <response code="200">The updated product.</response>
		/// <response code="400">The request is not valid.</response>
		/// <response code="404">Product with the given id does not exist.</response>
		[HttpPatch("{id:int}")]
		[Consumes(MediaTypeNames.Application.Json)]
		[ProducesResponseType<ProductDto>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
		[ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.ProblemJson)]
		[ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound, MediaTypeNames.Application.ProblemJson)]
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

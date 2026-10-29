using Microsoft.AspNetCore.Mvc;
using RestApiEshop.Application.Products;

namespace RestApiEshop.Controllers
{
	[ApiController]
	[Route("api/products")]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts(CancellationToken cancellationToken)
		{
			IReadOnlyList<ProductDto> products = await _productService.GetAllAsync(cancellationToken);

			return Ok(products);
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
	}
}

namespace RestApiEshop.Application.Products
{
	public record ProductDto(int Id, string Name, string ImgUri, decimal Price, string? Description);
}

namespace RestApiEshop.Domain.Entities
{
	public class Product
	{
		public const int NameMaxLength = 200;
		public const int ImgUriMaxLength = 2048;
		public const int DescriptionMaxLength = 4000;

		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string ImgUri { get; set; } = string.Empty;

		public decimal Price { get; set; }

		public string? Description { get; set; }
	}
}

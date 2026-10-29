using System.ComponentModel.DataAnnotations;
using RestApiEshop.Domain.Entities;

namespace RestApiEshop.Models
{
	public class UpdateProductDescriptionRequest
	{
		[MaxLength(Product.DescriptionMaxLength)]
		public required string? Description { get; set; }
	}
}

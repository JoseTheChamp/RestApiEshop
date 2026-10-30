using System.ComponentModel.DataAnnotations;
using RestApiEshop.Domain.Entities;

namespace RestApiEshop.Models
{
	public class UpdateProductDescriptionRequest
	{
		/// <summary>
		/// New description of the product. Send null to remove the description.
		/// </summary>
		[MaxLength(Product.DescriptionMaxLength)]
		public required string? Description { get; set; }
	}
}

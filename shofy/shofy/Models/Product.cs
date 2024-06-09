using System;
namespace shofy.Models
{
	public class Product : BaseEntity
	{
		public string Name  { get; set; }
		public float Price { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
		public ICollection<ProductImage> ProductImages { get; set; }
	}
}


using SignalRWebUI.Dtos.CategoryDtos;

namespace SignalRWebUI.Dtos.ProductDtos
{
	public class UpdateProductDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
		public bool Status { get; set; }
		public int CategoryId { get; set; }

        public  List<ResultCategoryDto> Categories { get; set; }
    }
}

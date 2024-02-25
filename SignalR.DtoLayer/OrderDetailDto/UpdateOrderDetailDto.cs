using SignalR.DtoLayer.OrderDto;
using SignalR.DtoLayer.ProductDto;

namespace SignalR.DtoLayer.OrderDetailDto
{
	public class UpdateOrderDetailDto
	{
		public int Id { get; set; }
		public int Count { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal TotalPrice { get; set; }


		public int ProductId { get; set; }
		public GetProductDto Product { get; set; }

		public int OrderId { get; set; }
		public GetOrderDto Order { get; set; }
	}
}

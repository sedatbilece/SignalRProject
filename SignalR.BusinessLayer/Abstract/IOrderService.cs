using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
	public interface IOrderService : IGenericService<Order>
	{
		public int TotalOrderCount();

		public int ActiveOrderCount();

		public decimal LastOrderPrice();
	}
}

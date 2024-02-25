using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface IOrderDal : IGenereciDal<Order>
	{

		public int TotalOrderCount();
		public int ActiveOrderCount();
		public decimal LastOrderPrice();
		public decimal TodayTotalPrice();
	}
}

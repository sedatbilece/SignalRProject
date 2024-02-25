using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class OrderDetailManager : IOrderDetailService
	{

		private readonly IOrderDetailDal _orderDetailDal;
		private readonly IOrderDal _orderDal;

		public OrderDetailManager(IOrderDetailDal orderDetailDal)
		{
			_orderDetailDal = orderDetailDal;
		}

		public void TAdd(OrderDetail entity)
		{
			_orderDetailDal.Add(entity);
			var order = _orderDal.GetById(entity.OrderId);

			if(order != null)
			{
				order.TotalPrice += entity.TotalPrice;
				_orderDal.Update(order);
			}

		}

		public void TDelete(OrderDetail entity)
		{
			_orderDetailDal.Delete(entity);
			var order = _orderDal.GetById(entity.OrderId);
			if(order != null)
			{
				order.TotalPrice -= entity.TotalPrice;
				_orderDal.Update(order);
			}
		}

		public List<OrderDetail> TGetAll()
		{
			throw new NotImplementedException();
		}

		public OrderDetail TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(OrderDetail entity)
		{
			throw new NotImplementedException();
		}
	}
}

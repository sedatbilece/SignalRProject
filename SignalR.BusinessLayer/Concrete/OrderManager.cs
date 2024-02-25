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
	public class OrderManager : IOrderService
	{
		private readonly IOrderDal _orderDal;
		private readonly IMoneyCaseDal _moneyCaseDal;

		public OrderManager(IOrderDal orderDal, IMoneyCaseDal moneyCaseDal)
		{
			_orderDal = orderDal;
			_moneyCaseDal = moneyCaseDal;
		}

		public int ActiveOrderCount()
		{
			return _orderDal.ActiveOrderCount();
		}

		public decimal LastOrderPrice()
		{
			return _orderDal.LastOrderPrice();
		}

		public void TAdd(Order entity)
		{
			_orderDal.Add(entity);
		}

		public void TDelete(Order entity)
		{
			_orderDal.Delete(entity);
		}

		public List<Order> TGetAll()
		{
			return _orderDal.GetAll();
		}

		public Order TGetById(int id)
		{
			return _orderDal.GetById(id);
		}

		public int TotalOrderCount()
		{
			return _orderDal.TotalOrderCount();
		}

		public void TUpdate(Order entity)
		{
			_orderDal.Update(entity);
			
			if(entity.Description=="Masa Kapatıldı")
			{
				_moneyCaseDal.Update(new MoneyCase
				{
					Id = 1,
					TotalAmount = _moneyCaseDal.GetById(1).TotalAmount + entity.TotalPrice
				});
			}
			
		}
	}
}

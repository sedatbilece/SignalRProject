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
	public class MoneyCaseManager : IMoneyCaseService
	{
		private readonly IMoneyCaseDal _moneyCaseDal;

		public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
		{
			_moneyCaseDal = moneyCaseDal;
		}

		public void TAdd(MoneyCase entity)
		{
			_moneyCaseDal.Add(entity);
		}

		public void TDelete(MoneyCase entity)
		{
			_moneyCaseDal.Delete(entity);
		}

		public List<MoneyCase> TGetAll()
		{
			return _moneyCaseDal.GetAll();
		}

		public MoneyCase TGetById(int id)
		{
			return _moneyCaseDal.GetById(id);
		}

		public decimal TotalMoneyCaseAmount()
		{
			
			return _moneyCaseDal.TotalMoneyCaseAmount();
		}

		public void TUpdate(MoneyCase entity)
		{
			_moneyCaseDal.Update(entity);
		}
	}
}

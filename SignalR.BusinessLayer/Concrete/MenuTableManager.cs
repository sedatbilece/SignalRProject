using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.EntityFramework;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class MenuTableManager : IMenuTableService
	{
		private readonly IMenuTableDal _efMenuTableDal;

		public MenuTableManager(IMenuTableDal efMenuTableDal)
		{
			_efMenuTableDal = efMenuTableDal;
		}

		public int MenuTableCount()
		{
			return _efMenuTableDal.MenuTableCount();
		}

		public void TAdd(MenuTable entity)
		{
			throw new NotImplementedException();
		}

		public void TDelete(MenuTable entity)
		{
			throw new NotImplementedException();
		}

		public List<MenuTable> TGetAll()
		{
			throw new NotImplementedException();
		}

		public MenuTable TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(MenuTable entity)
		{
			throw new NotImplementedException();
		}
	}

}

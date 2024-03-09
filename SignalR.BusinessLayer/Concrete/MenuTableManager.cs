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
			_efMenuTableDal.Add(entity);
		}

		public void TDelete(MenuTable entity)
		{
			_efMenuTableDal.Delete(entity);
		}

		public List<MenuTable> TGetAll()
		{
			return _efMenuTableDal.GetAll();
		}

		public MenuTable TGetById(int id)
		{
			return _efMenuTableDal.GetById(id);
		}

		public void TUpdate(MenuTable entity)
		{
			_efMenuTableDal.Update(entity);
		}
	}

}

using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
	{
		private readonly SignalRContext _context;
		public EfMenuTableDal(SignalRContext context) : base(context)
		{
			_context = context;
		}

		public int MenuTableCount()
		{
			return _context.MenuTables.Count();
		}

		public void MenuTableStatusChange(int id, bool statusType)
		{
			var value = _context.MenuTables.Find(id);
			value.Status = statusType;
			_context.SaveChanges();
		}
	}

}

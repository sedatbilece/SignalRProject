using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly SignalRContext _context;
        public EfProductDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public List<Product> ListProductsWithCategories()
        {
            var values = _context.Products.Include(x=>x.Category).ToList();
            return values;
        }

		public decimal ProductAvgPrice()
		{
			return _context.Products.Average(x => x.Price);
		}

		public decimal ProductAvgPriceByCategoryName(string name)
		{
			try
			{
				return _context.Products.Include(x => x.Category).Where(x => x.Category.Name.ToLower() == name.ToLower()).Average(x => x.Price);
			}
			catch (Exception)
			{
				return 0;
			}
		}

		public int ProductCount()
		{
			return _context.Products.Count();
		}

		public int ProductCountByCategoryName(string name)
		{
			return _context.Products.Include(x => x.Category).Where(x => x.Category.Name.ToLower() == name.ToLower()).Count();
		}

		public string ProductNameByMinOrMaxPrice(string type)
		{
			if (type.ToLower() == "min")
			{
				return _context.Products.Where(x => x.Price == _context.Products.Min(x => x.Price)).FirstOrDefault()?.Name;
			}
			else if (type.ToLower() == "max")
			{
				return _context.Products.Where(x => x.Price == _context.Products.Max(x => x.Price)).FirstOrDefault()?.Name;
			}
			else
			{
				return "invalid type";
			}
		}
	}
}

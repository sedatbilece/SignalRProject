using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TListProductsWithCategories();

		public int ProductCount();

		public int ProductCountByCategoryName(string name);

		public decimal ProductAvgPrice();

		public string ProductNameByMinOrMaxPrice(string type);

		public decimal ProductAvgPriceByCategoryName(string name);
	}
}

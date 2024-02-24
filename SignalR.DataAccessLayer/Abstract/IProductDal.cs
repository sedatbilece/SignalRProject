using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IProductDal :IGenereciDal<Product>
    {

        List<Product> ListProductsWithCategories();

        public int ProductCount();
        public int ProductCountByCategoryName(string name);
        public decimal ProductAvgPrice();
        public string ProductNameByMinOrMaxPrice(string type);
        public decimal ProductAvgPriceByCategoryName(string name);

    }
}

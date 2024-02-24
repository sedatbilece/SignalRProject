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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

		public decimal ProductAvgPrice()
		{
			return _productDal.ProductAvgPrice();
		}

		public decimal ProductAvgPriceByCategoryName(string name)
		{
			return _productDal.ProductAvgPriceByCategoryName(name);
		}

		public int ProductCount()
		{
			return _productDal.ProductCount();
		}

		public int ProductCountByCategoryName(string name)
		{
			return _productDal.ProductCountByCategoryName(name);
		}

		public string ProductNameByMinOrMaxPrice(string type)
		{
			return _productDal.ProductNameByMinOrMaxPrice(type);
		}

		public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> TGetAll()
        {
            return _productDal.GetAll();
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> TListProductsWithCategories()
        {
            return _productDal.ListProductsWithCategories();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}

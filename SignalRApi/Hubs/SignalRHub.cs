using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Hubs
{
	public class SignalRHub : Hub
	{
		private readonly SignalRContext _context;
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;

		public SignalRHub(ICategoryService categoryService, IProductService productService, SignalRContext context)
		{
			_categoryService = categoryService;
			_productService = productService;
			_context = context;
		}

		public async Task SendDashboardStatistics()
		{
			var value = _categoryService.CategoryCount();
			await Clients.All.SendAsync("ReceiveCategoryCount", value);

			var value2 = _productService.ProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", value2);

			var value3 = _categoryService.ActiveCategoryCount();
			await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

			var value4 = _categoryService.PassiveCategoryCount();
			await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

			var value6 = _productService.ProductAvgPrice();
			await Clients.All.SendAsync("ReceiveProductAvgPrice", value6.ToString("F2")+"₺");
		}

		public async Task ProductCountByCategoryName()
		{
			var categories = _categoryService.TGetAll();
			var value5 = new Dictionary<string, int>();
			foreach (var category in categories)
			{
				var value = _productService.ProductCountByCategoryName(category.Name);
				value5.Add(category.Name, value);
				
			}

			await Clients.All.SendAsync("ReceiveProductCountByCategoryName", value5);


		}



	}
}

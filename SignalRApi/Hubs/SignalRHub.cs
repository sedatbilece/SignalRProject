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
		private readonly IOrderService _orderService;
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly IMenuTableService _menuTableService;
		private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, SignalRContext context, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _context = context;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _notificationService = notificationService;
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

			var value7 = _productService.ProductNameByMinOrMaxPrice("min");
			await Clients.All.SendAsync("ReceiveProductNameByMinPrice", value7);

			var value8 = _productService.ProductNameByMinOrMaxPrice("max");
			await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", value8);

			var value10 = _orderService.TotalOrderCount();
			await Clients.All.SendAsync("ReceiveTotalOrderCount", value10);

			var value11 = _orderService.ActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", value11);

			var value12 = _orderService.LastOrderPrice();
			await Clients.All.SendAsync("ReceiveLastOrderPrice", value12+"₺");

			var value13 = _moneyCaseService.TotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value13 + "₺");

			var value14 = _orderService.TodayTotalPrice();
			await Clients.All.SendAsync("ReceiveTodayTotalPrice", value14 + "₺");

			var value15 = _menuTableService.MenuTableCount();
			await Clients.All.SendAsync("ReceiveMenuTableCount", value15);


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

		public async Task ProductAvgPriceByCategoryName()
		{
			var categories = _categoryService.TGetAll();
			var value9 = new Dictionary<string, string>();
			foreach (var category in categories)
			{
				var value = _productService.ProductAvgPriceByCategoryName(category.Name).ToString("F2") + "₺";
				value9.Add(category.Name, value);

			}

			await Clients.All.SendAsync("ReceiveProductAvgPriceByCategoryName", value9);


		}

		public async Task SendNotification()
		{
            var value = _notificationService.CountByStatus(false);
            await Clients.All.SendAsync("ReceiveCountByStatusFalse", value);

			var value2 = _notificationService.GetAllNotificationByStatus(false);
			await Clients.All.SendAsync("ReceiveAllByStatusFalse", value2);
        }

		public async Task SendMenuTable()
		{

			var value = _menuTableService.TGetAll();
			await Clients.All.SendAsync("ReceiveMenuTable", value);
		}


	}
}

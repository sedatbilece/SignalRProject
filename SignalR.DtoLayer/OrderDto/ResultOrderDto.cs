using SignalR.DtoLayer.OrderDetailDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.OrderDto
{
	public class GetOrderDto
	{
		public int Id { get; set; }
		public string TableNumber { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public decimal TotalPrice { get; set; }

		public List<ResultOrderDetailDto> OrderDetails { get; set; }
	}
}

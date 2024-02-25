using AutoMapper;
using SignalR.DtoLayer.OrderDetailDto;

namespace SignalRApi.Mapping
{
	public class OrderDetail : Profile
	{

		public OrderDetail()
		{
			CreateMap<OrderDetail, ResultOrderDetailDto>().ReverseMap();
			CreateMap<OrderDetail, CreateOrderDetailDto>().ReverseMap();
			CreateMap<OrderDetail, GetOrderDetailDto>().ReverseMap();
			CreateMap<OrderDetail, UpdateOrderDetailDto>().ReverseMap();
		}
	}
}

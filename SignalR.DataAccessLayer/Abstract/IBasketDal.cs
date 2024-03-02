using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IBasketDal : IGenereciDal<Basket>
    {

        List<Basket> GetBasketByMenuTableNumber(int tableNumber);
    }
}

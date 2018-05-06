using System.Collections.Generic;
using WpfAgroStoreApp.Model;

namespace WpfAgroStoreApp.Services.OrderService
{
    public interface IOrderService
    {
        List<Order> LoadOrders();
        Order StoreOrder(int customerId, int carrierId, int paymentId);
        bool EditOrder(Order order);
        bool DeleteOrder(Order order);
    }
}

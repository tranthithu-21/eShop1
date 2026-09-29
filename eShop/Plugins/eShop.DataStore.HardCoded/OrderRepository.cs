using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System.Collections.Generic;
using System.Linq;

namespace eShop.DataStore.HardCoded
{
    public class OrderRepository : IOrderRepository
    {
        private Dictionary<int, Order> orders;

        public OrderRepository()
        {
            orders = new Dictionary<int, Order>();
        }

        public int CreateOrder(Order order)
        {
            order.OrderId = orders.Count + 1;
            orders.Add(order.OrderId.Value, order);
            return order.OrderId.Value;
        }

        public Order GetOrder(int orderId)
        {
            return orders.GetValueOrDefault(orderId);
        }

        public Order GetOrderByUniqueId(string uniqueId)
        {
            return orders.Values.FirstOrDefault(x => x.UniqueId == uniqueId);
        }

        public void UpdateOrder(Order order)
        {
            if (order == null || !order.OrderId.HasValue) return;

            if (orders.ContainsKey(order.OrderId.Value))
            {
                orders[order.OrderId.Value] = order;
            }
        }
    }
}

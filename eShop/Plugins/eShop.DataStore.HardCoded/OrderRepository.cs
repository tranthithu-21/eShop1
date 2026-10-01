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
            
            // Seed with default orders to match the teacher's output
            orders.Add(1, new Order
            {
                OrderId = 1,
                UniqueId = "1",
                DatePlaced = new System.DateTime(2023, 6, 2),
                CustomerName = "Long",
                CustomerCity = "Hue",
                CustomerStateProvince = "Hue",
                CustomerCountry = "VN"
            });

            orders.Add(2, new Order
            {
                OrderId = 2,
                UniqueId = "2",
                DatePlaced = new System.DateTime(2023, 6, 2),
                CustomerName = "Ha Ngoc Long",
                CustomerCity = "Hue",
                CustomerStateProvince = "Hue",
                CustomerCountry = "VN"
            });
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

        public IEnumerable<Order> GetOutstandingOrders()
        {
            var allOrders = orders.Values;
            return allOrders.Where(x => x.DateProcessed == null);
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            var allOrders = orders.Values;
            return allOrders.Where(x => x.DateProcessed != null);
        }
    }
}

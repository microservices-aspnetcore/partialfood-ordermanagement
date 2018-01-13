using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PartialFoods.Services.OrderManagementServer.Entities
{
    public class OrderRepository : IOrderRepository
    {
        private OrdersContext context;

        public OrderRepository(OrdersContext context)
        {
            this.context = context;
        }

        public OrderActivity AddActivity(OrderActivity activity)
        {
            try
            {
                context.Activities.Add(activity);
                context.SaveChanges();
                return activity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine($"Failed to add order activity: {ex.ToString()}");
                return null;
            }
        }

        public bool OrderExists(string orderID)
        {
            try
            {
                var existing = context.Orders.FirstOrDefault(o => o.OrderID == orderID);
                return existing != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine($"Failed to check order existence: {ex.ToString()}");
                return false;
            }
        }
        public Order GetOrder(string orderID)
        {
            Console.WriteLine($"Fetching order {orderID}");
            try
            {
                var existing = context.Orders
                    .Include(o => o.LineItems)
                    .Include(o => o.Activities)
                    .FirstOrDefault(o => o.OrderID == orderID);
                return existing;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine($"Failed to query order {ex.ToString()}");
                return null;
            }
        }

        public Order Add(Order order)
        {
            Console.WriteLine($"Adding order {order.OrderID} to repository.");
            try
            {
                var existing = context.Orders.FirstOrDefault(o => o.OrderID == order.OrderID);
                if (existing != null)
                {
                    Console.WriteLine($"Bypassing add for order {order.OrderID} - already exists.");
                    return order;
                }
                context.Add(order);
                context.SaveChanges();
                return order;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine($"Failed to save changes in db context: {ex.ToString()}");
                return null;
            }
        }
    }
}
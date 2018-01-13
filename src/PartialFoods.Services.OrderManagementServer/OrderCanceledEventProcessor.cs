using PartialFoods.Services.OrderManagementServer.Entities;
using System;
using System.Linq;

namespace PartialFoods.Services.OrderManagementServer
{
    public class OrderCanceledEventProcessor
    {
        private IOrderRepository orderRepository;

        public OrderCanceledEventProcessor(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public bool HandleOrderCanceledEvent(OrderCanceledEvent orderCanceledEvent)
        {
            Console.WriteLine("Handling order canceled event");

            var result = this.orderRepository.AddActivity(new OrderActivity
            {
                OccuredOn = (long)orderCanceledEvent.CreatedOn,
                ActivityID = orderCanceledEvent.ActivityID,
                UserID = orderCanceledEvent.UserID,
                OrderID = orderCanceledEvent.OrderID,
                ActivityType = ActivityType.Canceled
            });
            return (result != null);
        }
    }
}
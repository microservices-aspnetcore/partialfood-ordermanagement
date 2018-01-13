using PartialFoods.Services.OrderManagementServer.Entities;
using System.Linq;
using System;

namespace PartialFoods.Services.OrderManagementServer
{
    public class OrderAcceptedEventProcessor
    {
        private IOrderRepository orderRepository;

        public OrderAcceptedEventProcessor(IOrderRepository repository)
        {
            this.orderRepository = repository;
        }

        public bool HandleOrderAcceptedEvent(OrderAcceptedEvent evt)
        {
            Console.WriteLine("Handling order accepted event.");
            Order result = orderRepository.Add(new Order
            {
                OrderID = evt.OrderID,
                CreatedOn = (long)evt.CreatedOn,
                TaxRate = (int)evt.TaxRate,
                UserID = evt.UserID,
                LineItems = (from itm in evt.LineItems
                             select new PartialFoods.Services.OrderManagementServer.Entities.LineItem
                             {
                                 SKU = itm.SKU,
                                 OrderID = evt.OrderID,
                                 Quantity = (int)itm.Quantity,
                                 UnitPrice = (int)itm.UnitPrice
                             }).ToArray()
            });

            return (result != null);
        }
    }
}
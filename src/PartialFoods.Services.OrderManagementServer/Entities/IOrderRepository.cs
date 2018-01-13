namespace PartialFoods.Services.OrderManagementServer.Entities
{
    public interface IOrderRepository
    {
        Order Add(Order order);
        Order GetOrder(string orderID);
        OrderActivity AddActivity(OrderActivity activity);

        bool OrderExists(string orderID);
    }
}
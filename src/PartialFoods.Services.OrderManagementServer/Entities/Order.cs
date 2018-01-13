using System.Collections.Generic;

namespace PartialFoods.Services.OrderManagementServer.Entities
{
    public class Order
    {
        public string OrderID { get; set; }
        public long CreatedOn { get; set; }
        public string UserID { get; set; }
        public ICollection<LineItem> LineItems { get; set; } = new List<LineItem>();
        public ICollection<OrderActivity> Activities { get; set; } = new List<OrderActivity>();

        public int TaxRate { get; set; }
    }

    public class LineItem
    {
        public string OrderID { get; set; }
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
    }
}
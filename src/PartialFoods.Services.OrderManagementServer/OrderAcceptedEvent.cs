using System.Collections.Generic;
using Newtonsoft.Json;

namespace PartialFoods.Services.OrderManagementServer
{
    public class OrderAcceptedEvent
    {
        [JsonProperty("order_id")]
        public string OrderID;

        [JsonProperty("created_on")]
        public ulong CreatedOn;

        [JsonProperty("user_id")]
        public string UserID;

        [JsonProperty("tax_rate")]
        public uint TaxRate;

        [JsonProperty("line_items")]
        public ICollection<EventLineItem> LineItems;
    }

    public class EventLineItem
    {
        [JsonProperty("sku")]
        public string SKU;

        [JsonProperty("unit_price")]
        public uint UnitPrice;

        [JsonProperty("quantity")]
        public uint Quantity;
    }
}
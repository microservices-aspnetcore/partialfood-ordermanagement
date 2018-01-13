using Newtonsoft.Json;

namespace PartialFoods.Services.OrderManagementServer
{
    public class OrderCanceledEvent
    {
        [JsonProperty("created_on")]
        public ulong CreatedOn { get; set; }

        [JsonProperty("order_id")]
        public string OrderID { get; set; }

        [JsonProperty("user_id")]
        public string UserID { get; set; }

        [JsonProperty("activity_id")]
        public string ActivityID { get; set; }
    }
}
namespace PartialFoods.Services.OrderManagementServer.Entities
{
    public class OrderActivity
    {
        public string OrderID { get; set; }
        public ActivityType ActivityType { get; set; }
        public string UserID { get; set; }
        public long OccuredOn { get; set; }
        public string ActivityID { get; set; }
    }

    public enum ActivityType
    {
        Canceled = 1,
        Unknown = 0
    }
}
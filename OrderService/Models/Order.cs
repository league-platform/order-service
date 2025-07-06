using Amazon.DynamoDBv2.DataModel;

namespace OrderService.Models
{
    [DynamoDBTable("Orders")]
    public class Order
    {
        [DynamoDBHashKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [DynamoDBProperty]
        public string Item { get; set; }

        [DynamoDBProperty]
        public double Total { get; set; }

        [DynamoDBProperty]
        public string Status { get; set; }

        [DynamoDBProperty]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

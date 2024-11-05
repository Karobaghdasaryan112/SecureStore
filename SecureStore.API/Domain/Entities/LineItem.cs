using System.Text.Json.Serialization;

namespace SecureStore.API.Domain.Entities
{
    public class LineItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid OrderId { get; set; }

        [JsonIgnore]
        public Order Order { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; } = 1;
    }
}

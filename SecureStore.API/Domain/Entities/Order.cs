using System.Text.Json.Serialization;

namespace SecureStore.API.Domain.Entities
{
    public class Order
    {
        public Order()
        { }
        public Guid Id { get; set; } = Guid.NewGuid();

        public Order(Customer customer) : this()
        {
            Customer = customer;
            CustomerName = $"{customer.User.FirstName} {customer.User.LastName}";
            CustomerId = customer.Id;
            Address = customer.Address;
        }

        public Guid CustomerId { get; set; }
        [JsonIgnore]

        public Customer Customer { get; set; }

        public string CustomerName { get; set; }
 
        public int InvoiceNumber { get; set; } = 0;

        public string Address { get; set; }

        public List<LineItem> LineItems { get; set; } = new List<LineItem>();

        public DateTime DatePlaced { get; set; } = DateTime.Now;

        public DateTime? DateFilled { get; set; } = null;

        public OrderStatus Status { get; set; } = OrderStatus.Open;

        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Unpaid;

        public Term Term { get; set; }

        public decimal Subtotal => LineItems.Sum(lineItem => lineItem.Product.ListPrice * lineItem.Quantity);

        public decimal Tax => Subtotal * .095m;

        public decimal GrandTotal => Subtotal + Tax;

        public override string ToString() => InvoiceNumber.ToString();
    }

    public enum Term
    {
        Net1,
        Net5,
        Net15,
        Net30
    }

    public enum PaymentStatus
    {
        Unpaid,
        Paid
    }

    public enum OrderStatus
    {
        Open,
        Filled,
        Cancelled
    }
}

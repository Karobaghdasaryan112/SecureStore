namespace SecureStore.API.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public string Company { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
        public ICollection<Order> Orders { get; set; }

        public override string ToString() => $"{User.FirstName} {User.LastName}";
        public bool Equals(Customer other) =>
            Company == other.Company &&
            Phone == other.Phone &&
            Address == other.Address;
    }
}

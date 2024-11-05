namespace SecureStore.API.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public string Color { get; set; }

        public int DaysToManufacture { get; set; }

        public decimal StandardCost { get; set; }

        public decimal ListPrice { get; set; }

        public decimal Weight { get; set; }

        public string Description { get; set; }

        public override string ToString() => $"{Name} \n{ListPrice}";
    }
}

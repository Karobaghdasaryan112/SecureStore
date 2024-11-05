using SecureStore.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Extennsions.Builder
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var order1Id = Guid.NewGuid();
            var order2Id = Guid.NewGuid();
            var product1Id = Guid.NewGuid();
            var product2Id = Guid.NewGuid();


            modelBuilder.Entity<Product>().HasData(
                new Product { Id = product1Id, Name = "Laptop", Color = "Black", DaysToManufacture = 5, StandardCost = 500, ListPrice = 800, Weight = 2.5m, Description = "Powerful laptop" },
                new Product { Id = product2Id, Name = "Smartphone", Color = "Blue", DaysToManufacture = 3, StandardCost = 200, ListPrice = 350, Weight = 0.3m, Description = "Compact smartphone" }
            );


            var user1Id = Guid.NewGuid();
            var user2Id = Guid.NewGuid();
            var customer1Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User { Id = user1Id, FirstName = "Ivan", LastName = "Ivanov", UserName = "ivanov", Password = "password123", Email = "ivan@example.com", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new User { Id = user2Id, FirstName = "Petr", LastName = "Petrov", UserName = "petrov", Password = "password456", Email = "petr@example.com", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = customer1Id, UserId = user1Id, Company = "Tech Co", Phone = "123-456-7890", Address = "123 Tech Street" }
            );


            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = order1Id,
                    CustomerId = customer1Id,
                    CustomerName = "Ivan Ivanov",
                    InvoiceNumber = 1001,
                    Address = "123 Tech Street",
                    DatePlaced = DateTime.Now,
                    Status = OrderStatus.Open,
                    PaymentStatus = PaymentStatus.Unpaid,
                    Term = Term.Net30
                }
            );


            modelBuilder.Entity<LineItem>().HasData(
                new LineItem
                {
                    Id = Guid.NewGuid(),
                    OrderId = order1Id,  
                    ProductId = product1Id, 
                    Quantity = 1
                },
                new LineItem
                {
                    Id = Guid.NewGuid(),
                    OrderId = order1Id,  
                    ProductId = product2Id,
                    Quantity = 2
                }
            );

        }
    }
}
using SecureStore.API.Domain.Entities;

namespace SecureStore.API.Services.Interfaces
{
    public interface ICustomerService
    {
         ICollection<Order> GetOrdersByCustomer(Guid customerId); 
    }
}

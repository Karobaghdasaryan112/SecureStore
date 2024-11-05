using SecureStore.API.AppDbContext;
using SecureStore.API.Domain.Entities;

namespace SecureStore.API.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(Guid Customerid);
        ICollection<Order> GetCustomerOrders(Guid CustomerId);

    }
}

using Microsoft.EntityFrameworkCore;
using SecureStore.API.AppDbContext;
using SecureStore.API.Domain.Entities;
using SecureStore.API.Repositories.Interfaces;
namespace SecureStore.API.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private ApplicationDbContext _context { get; set; }
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        Customer ICustomerRepository.GetCustomerById(Guid Customerid)
        {
            throw new NotImplementedException();
        }

        ICollection<Order> ICustomerRepository.GetCustomerOrders(Guid customerId)
        {
            var orders = _context.Orders
                .Include(order => order.Customer)
                .ThenInclude(Customer => Customer.User)
                .Include(order => order.LineItems)
                    .ThenInclude(lineItem => lineItem.Product)
                .Where(order => order.CustomerId == customerId)
                .ToList();
            return orders;
        }
    }
}

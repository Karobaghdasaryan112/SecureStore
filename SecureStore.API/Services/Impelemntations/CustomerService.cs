using SecureStore.API.Domain.Entities;
using SecureStore.API.Repositories.Interfaces;
using SecureStore.API.Services.Interfaces;

namespace SecureStore.API.Services.Impelemntations
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository {  get; set; }
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        ICollection<Order> ICustomerService.GetOrdersByCustomer(Guid customerId)
        {
            return _customerRepository.GetCustomerOrders(customerId);    
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SecureStore.API.AppDbContext;
using SecureStore.API.Domain.Entities;
using SecureStore.API.Repositories.Interfaces;

namespace SecureStore.API.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationDbContext _context { get; set; }
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        ICollection<LineItem> IOrderRepository.GetOrderLineItems(Guid OrderId)
        {
            throw new NotImplementedException();
        }

        Order IOrderRepository.GetOrderById(Guid OrderId)
        {
            throw new NotImplementedException();
        }

        List<Order> IOrderRepository.GetOrdersByCustomer(string UserName)
        {
            return _context.Orders.
                Include(Order => Order.LineItems).
                ThenInclude(Line => Line.Product).
                Include(Order => Order.Customer).
                Where(order => order.Customer.User.UserName == UserName).ToList();
        }

        void IOrderRepository.DeleteOrderByCstomerId(Guid CustomerId)
        {
            throw new NotImplementedException();
        }

        void IOrderRepository.DeleteOrerByOrderId(Guid OrderId)
        {
            throw new NotImplementedException();
        }

        void IOrderRepository.UpdateOrder(Guid OrderId, Order NewOrder)
        {
            throw new NotImplementedException();
        }
    }
}

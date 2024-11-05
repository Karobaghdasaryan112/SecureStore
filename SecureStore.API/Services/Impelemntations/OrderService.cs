using SecureStore.API.Domain.Entities;
using SecureStore.API.Repositories.Interfaces;
using SecureStore.API.Services.Interfaces;

namespace SecureStore.API.Services.Impelemntations
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository {  get; set; }
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        void IOrderService.DeleteOrderByCstomerId(Guid CustomerId)
        {
            throw new NotImplementedException();
        }

        void IOrderService.DeleteOrerByOrderId(Guid OrderId)
        {
            throw new NotImplementedException();
        }

        List<Order> IOrderService.GetOrdersByCustomer(string UserName)
        {
            return _orderRepository.GetOrdersByCustomer(UserName);
        }

        Order IOrderService.GetOrderById(Guid OrderId)
        {
            throw new NotImplementedException();
        }

        ICollection<LineItem> IOrderService.GetOrderLineItems(Guid OrderId)
        {
            throw new NotImplementedException();
        }

        void IOrderService.UpdateOrder(Guid OrderId, Order NewOrder)
        {
            throw new NotImplementedException();
        }
    }
}

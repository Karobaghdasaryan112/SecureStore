using SecureStore.API.Domain.Entities;

namespace SecureStore.API.Services.Interfaces
{
    public interface IOrderService
    {
        //Read
        ICollection<LineItem> GetOrderLineItems(Guid OrderId);
        Order GetOrderById(Guid OrderId);
        List<Order> GetOrdersByCustomer(string UserName);


        //Write
        void DeleteOrderByCstomerId(Guid CustomerId);
        void DeleteOrerByOrderId(Guid OrderId);


        //Delete
        void UpdateOrder(Guid OrderId, Order NewOrder);
    }
}

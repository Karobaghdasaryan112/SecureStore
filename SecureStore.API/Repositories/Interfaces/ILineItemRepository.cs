using SecureStore.API.Domain.Entities;

namespace SecureStore.API.Repositories.Interfaces
{
    public interface ILineItemRepository
    {
        LineItem GetLineItem(Guid LineItemId);
        LineItem CreateLineItem(Guid ProductId, int Quantity, Guid OrderId);
    }
}

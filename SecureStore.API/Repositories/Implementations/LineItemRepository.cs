using SecureStore.API.AppDbContext;
using SecureStore.API.Domain.Entities;
using SecureStore.API.Repositories.Interfaces;

namespace SecureStore.API.Repositories.Implementations
{
    public class LineItemRepository : ILineItemRepository
    {
        private ApplicationDbContext _context { get; set; }
        public LineItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        LineItem ILineItemRepository.GetLineItem(Guid LineItemId)
        {
            throw new NotImplementedException();
        }

        LineItem ILineItemRepository.CreateLineItem(Guid ProductId, int Quantity, Guid OrderId)
        {
            throw new NotImplementedException();
        }
    }
}

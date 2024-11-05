using SecureStore.API.AppDbContext;
using SecureStore.API.Domain.Entities;
using SecureStore.API.Repositories.Interfaces;

namespace SecureStore.API.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context { get; set; }
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        void IProductRepository.CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        Product IProductRepository.GetProductById(Guid productId)
        {
            throw new NotImplementedException();
        }

        Product IProductRepository.GetProductGyName(string ProductName)
        {
            throw new NotImplementedException();
        }

        void IProductRepository.UpdateProduct(Guid OldProductId, Product NewProduct)
        {
            throw new NotImplementedException();
        }

        ICollection<Product> IProductRepository.GetAllProducts()
        {
            return _context.Products.ToList();
        }
    }
}

using SecureStore.API.Domain.Entities;
using SecureStore.API.Repositories.Implementations;
using SecureStore.API.Repositories.Interfaces;
using SecureStore.API.Services.Interfaces;

namespace SecureStore.API.Services.Impelemntations
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository {  get; set; }
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        void IProductService.CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        ICollection<Product> IProductService.GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        Product IProductService.GetProductById(Guid productId)
        {
            throw new NotImplementedException();
        }

        Product IProductService.GetProductGyName(string ProductName)
        {
            throw new NotImplementedException();
        }

        void IProductService.UpdateProduct(Guid OldProductId, Product NewProduct)
        {
            throw new NotImplementedException();
        }
    }
}

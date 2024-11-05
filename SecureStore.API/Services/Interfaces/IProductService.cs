using SecureStore.API.Domain.Entities;
using SecureStore.API.Validation;

namespace SecureStore.API.Services.Interfaces
{
    public interface IProductService
    {
        void CreateProduct(Product product);
        Product GetProductById(Guid productId);
        Product GetProductGyName(string ProductName);
        void UpdateProduct(Guid OldProductId, Product NewProduct);

        ICollection<Product> GetAllProducts();
    }
}

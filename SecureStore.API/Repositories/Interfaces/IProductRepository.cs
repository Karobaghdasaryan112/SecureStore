using SecureStore.API.Domain.Entities;

namespace SecureStore.API.Repositories.Interfaces
{
    public interface IProductRepository
    {
         void CreateProduct(Product product);
         Product GetProductById(Guid productId);
         Product GetProductGyName(string ProductName);
        void UpdateProduct(Guid OldProductId,Product NewProduct);    

        ICollection<Product> GetAllProducts();
    }
}

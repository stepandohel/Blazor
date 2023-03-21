using Domain.Data.Entities;

namespace Shop.Api.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task UpdateProductAsync(int id, Product product);
        Task DeleteProductAsync(int id);
        Task CreateProductAsync(Product product);
    }
}

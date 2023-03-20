using Domain.Data.Entities;

namespace Shop.Api.Repositories.Contracts
{
    public interface IProdcutRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<ProductCategory>> GetAllCategoriesAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<ProductCategory> GetCategoryByIdAsync(int id); 
    }
}

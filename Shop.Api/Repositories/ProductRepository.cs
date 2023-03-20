using Domain.Data;
using Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Shop.Api.Repositories.Contracts;

namespace Shop.Api.Repositories
{
    public class ProductRepository : IProdcutRepository
    {
        private readonly AppDBContext _appDBContext;

        public ProductRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<IEnumerable<ProductCategory>> GetAllCategoriesAsync()
        {
            return await _appDBContext.ProductCategories.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _appDBContext.Products.Include(x => x.ProductCategory).ToListAsync();
        }

        public Task<ProductCategory> GetCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _appDBContext.Products.Include(x => x.ProductCategory).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

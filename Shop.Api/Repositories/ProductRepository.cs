using Domain.Data;
using Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Shop.Api.Repositories.Contracts;

namespace Shop.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _appDBContext;

        public ProductRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task CreateProductAsync(Product product)
        {
            await _appDBContext.Products.AddAsync(product);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var item = await _appDBContext.Products.FindAsync(id);
            _appDBContext.Products.Remove(item);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _appDBContext.Products.Include(x => x.ProductCategory).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _appDBContext.Products.Include(x => x.ProductCategory).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateProductAsync(int id, Product product)
        {
            _appDBContext.Products.Update(product);
            await _appDBContext.SaveChangesAsync();
        }
    }
}

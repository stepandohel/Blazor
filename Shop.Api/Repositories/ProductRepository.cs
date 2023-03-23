using Domain.Data;
using Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Shop.Api.Repositories.Contracts;

namespace Shop.Api.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly AppDBContext _appDBContext;

        public ProductRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task CreateAsync(Product product)
        {
            await _appDBContext.Products.AddAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _appDBContext.Products.FindAsync(id);
            _appDBContext.Products.Remove(item);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _appDBContext.Products.Include(x => x.ProductCategory).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _appDBContext.Products.Include(x => x.ProductCategory).FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Product product)
        {
            _appDBContext.Products.Update(product);
        }
    }
}

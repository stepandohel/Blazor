using Domain.Data;
using Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Shop.Api.Repositories.Contracts;

namespace Shop.Api.Repositories
{
    public class ProductCategoryRepository : IRepository<ProductCategory>
    {
        private readonly AppDBContext _dbContext;

        public ProductCategoryRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(ProductCategory item)
        {
            await _dbContext.ProductCategories.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _dbContext.ProductCategories.FindAsync(id);
            if (item is not null)
                _dbContext.Remove(item);
        }

        public async Task<IEnumerable<ProductCategory>> GetAllAsync()
        {
            return await _dbContext.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory> GetByIdAsync(int id)
        {
            var item = await _dbContext.ProductCategories.FindAsync(id);
            if (item is not null)
                return item;
            throw new NullReferenceException();
        }

        public void Update(ProductCategory item)
        {
            _dbContext.ProductCategories.Update(item);
        }
    }
}

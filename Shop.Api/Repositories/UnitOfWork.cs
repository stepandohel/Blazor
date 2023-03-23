using Domain.Data;
using Domain.Data.Entities;
using Shop.Api.Repositories.Contracts;

namespace Shop.Api.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private AppDBContext _dbContext;
        private IRepository<Product> _productRepository;
        private IRepository<ProductCategory> _productCategoryRepository;
        private bool _isDisposed = false;
        public UnitOfWork(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }
        public IRepository<Product> ProductRepository
        {
            get
            {
                if (_productRepository is null)
                {
                    _productRepository = new ProductRepository(_dbContext);
                }
                return _productRepository;
            }
        }
        public IRepository<ProductCategory> ProductCategoryRepository
        {
            get
            {
                if (_productCategoryRepository is null)
                {
                    _productCategoryRepository = new ProductCategoryRepository(_dbContext);
                }
                return _productCategoryRepository;
            }
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async void Dispose()
        {
            await Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual async Task Dispose(bool disposing)
        {
            if (!this._isDisposed)
            {
                if (disposing)
                {
                    await _dbContext.DisposeAsync();
                }
                this._isDisposed = true;
            }
        }
    }
}

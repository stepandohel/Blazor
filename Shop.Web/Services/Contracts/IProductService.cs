using Models.Dtos;

namespace Shop.Web.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductDtosAsync();
        Task<ProductDto> GetProductsByIdAsync(int id);
    }
}

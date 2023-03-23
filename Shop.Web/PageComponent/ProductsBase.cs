using Microsoft.AspNetCore.Components;
using Models.Dtos;
using Shop.Web.Services.Contracts;

namespace Shop.Web.PageComponent
{
    public class ProductsBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Products = await ProductService.GetProductDtosAsync();
        }
        protected IOrderedEnumerable<IGrouping<int, ProductDto>> GetGroupedProductDtosByCategory()
        {
            return Products.GroupBy(x => x.ProductCategoryId).OrderBy(x => x.Key);
        }
        protected string GetProductCategoryName(IGrouping<int, ProductDto> groupedProductDto)
        {
            return groupedProductDto.FirstOrDefault(x => x.ProductCategoryId == groupedProductDto.Key).ProductCategoryName;
        }
    }
}

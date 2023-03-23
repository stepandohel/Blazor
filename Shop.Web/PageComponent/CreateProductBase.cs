using Microsoft.AspNetCore.Components;
using Models.Dtos;
using Shop.Web.Services.Contracts;

namespace Shop.Web.PageComponent
{
    public class CreateProductBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IProductService productService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ProductDto Product { get; set; } = new ProductDto();

        protected async Task CreateProduct_Click()
        {
            Product.ProductCategoryName = "";
            Product.ImageURL = "";
            await productService.CreateProduct(Product);
            NavigationManager.NavigateTo("/");
        }
    }
}

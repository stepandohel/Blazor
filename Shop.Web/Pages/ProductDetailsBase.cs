using Microsoft.AspNetCore.Components;
using Models.Dtos;
using Shop.Web.Services.Contracts;

namespace Shop.Web.Pages
{
    public class ProductDetailsBase :  ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IProductService productService { get; set; }
        public ProductDto Product { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Product = await productService.GetProductsByIdAsync(Id);
        }
    }
}

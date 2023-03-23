using Microsoft.AspNetCore.Components;
using Models.Dtos;
using Shop.Web.Services.Contracts;

namespace Shop.Web.PageComponent
{
    public class ProductFromBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IProductService productService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ProductDto Product { get; set; }
        public ProductDto updatedProduct { get; set; } = new ProductDto();


        public bool _isInit;

        protected override async Task OnInitializedAsync()
        {
            Product = await productService.GetProductsByIdAsync(Id);
            _isInit = true;
        }

        protected async Task UpdateProduct_Click()
        {
            await productService.UpdateProductById(Id, Product);
            NavigationManager.NavigateTo("/");
        }
    }
}

using Microsoft.AspNetCore.Components;
using Models.Dtos;
using Shop.Web.Services.Contracts;

namespace Shop.Web.PageComponent
{
    public class ProductDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IProductService productService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public ProductDto Product { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Product = await productService.GetProductsByIdAsync(Id);
        }
        protected async Task DeleteProduct_Click(ProductDto product)
        {
            await productService.DeleteProductById(product);
            NavigationManager.NavigateTo("/");
        }
        protected async Task SendToUpdateForm_Click(int id)
        {
            NavigationManager.NavigateTo($"/ProductForm/{id}");
        }
    }
}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Models.Dtos;
using Shop.Web.Services.Contracts;

namespace Shop.Web.Pages
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

        public EditContext editContext;

        public bool _isInit;

        protected override async Task OnInitializedAsync()
        {
            Product = await productService.GetProductsByIdAsync(Id);
            editContext = new(Product);
            _isInit = true;
        }

        protected async Task UpdateProduct_Click()
        {
            await productService.UpdateProductById(Id, Product);
            NavigationManager.NavigateTo("/");
        }
        protected async void OnFileSelected(InputFileChangeEventArgs e)
        {
            using (var fs = File.Create($"D:\\Projects\\Internship\\Blazor\\" + e.File.Name))
            {
                var sad= e.GetMultipleFiles().First();
                await sad.OpenReadStream().CopyToAsync(fs);
            }
        }
    }
}

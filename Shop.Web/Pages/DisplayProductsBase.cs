using Microsoft.AspNetCore.Components;
using Models.Dtos;

namespace Shop.Web.Pages
{
    public class DisplayProductsBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDto> Products { get; set; }

    }
}

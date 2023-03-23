using Microsoft.AspNetCore.Components;
using Models.Dtos;

namespace Shop.Web.PageComponent
{
    public class DisplayProductsBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDto> Products { get; set; }
    }
}

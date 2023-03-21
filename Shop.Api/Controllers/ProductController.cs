using AutoMapper;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using Shop.Api.Repositories.Contracts;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _prodcutRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository prodcutRepository, IMapper mapper)
        {
            _prodcutRepository = prodcutRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsAsync()
        {
            var items =  await _prodcutRepository.GetAllProductsAsync();
            var returnedItems = _mapper.Map<List<ProductDto>>(items);
            
            return Ok(returnedItems);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProductByIdAsync(int id)
        {
            var items = await _prodcutRepository.GetProductByIdAsync(id);
            var returnedItems = _mapper.Map<ProductDto>(items);

            return Ok(returnedItems);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProductById(int id)
        {
            await _prodcutRepository.DeleteProductAsync(id);
            return (NoContent());
        }

        [HttpPut("{id:int}")]
        public async Task UpdateProduct(int id, ProductDto productDto)
        {
            var item = _mapper.Map<Product>(productDto);
            await _prodcutRepository.UpdateProductAsync(id, item);
        }
    }
}

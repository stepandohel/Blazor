using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using Shop.Api.Repositories.Contracts;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IProdcutRepository _prodcutRepository;
        private readonly IMapper _mapper;

        public ProductController(IProdcutRepository prodcutRepository, IMapper mapper)
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

    }
}

using AutoMapper;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using Shop.Api.Repositories;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsAsync()
        {
            var items = await _unitOfWork.ProductRepository.GetAllAsync();
            var returnedItems = _mapper.Map<List<ProductDto>>(items);

            return Ok(returnedItems);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProductByIdAsync(int id)
        {
            var items = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            var returnedItems = _mapper.Map<ProductDto>(items);

            return Ok(returnedItems);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProductById(int id)
        {
            await _unitOfWork.ProductRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return (NoContent());
        }

        [HttpPut("{id:int}")]
        public async Task UpdateProduct(int id, ProductDto productDto)
        {
            var item = _mapper.Map<Product>(productDto);
            _unitOfWork.ProductRepository.Update(item);
            await _unitOfWork.SaveChangesAsync();
        }

        [HttpPost]
        public async Task CreateProduct(ProductDto productDto)
        {
            var item = _mapper.Map<Product>(productDto);
            await _unitOfWork.ProductRepository.CreateAsync(item);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

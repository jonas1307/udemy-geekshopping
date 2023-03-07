using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Models;
using GeekShopping.ProductAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productRepository.FindAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var product = await _productRepository.FindById(id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductVO vo)
        {
            if (vo == null) return BadRequest();

            return Ok(await _productRepository.Create(vo));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductVO vo)
        {
            if (vo == null) return BadRequest();

            return Ok(await _productRepository.Update(vo));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            if (await _productRepository.Delete(id))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.API.Data;
using Products.API.Models.DTOs;
using Products.API.Models.Entities;

namespace Products.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase {
        private readonly ProductContext context;
        private readonly IMapper mapper;

        public ProductsController(ProductContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> get() {
            var productList = await context.Products.ToListAsync();
            var mapped = mapper.Map<List<ProductDTO>>(productList);
            return Ok(mapped);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductDTO>> getById(int id) {
            var product = await context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (product == null)
                return NotFound();
            var mapped = mapper.Map<ProductDTO>(product);
            return Ok(mapped);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> post([FromBody]ProductDTO productDTO) {
            var product = mapper.Map<ProductDTO, Product>(productDTO);
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return Ok(mapper.Map<ProductDTO>(product));
        }

        [HttpPut]
        public async Task<ActionResult<ProductDTO>> put([FromBody]ProductDTO productDTO) {
            var product = await context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ProductId == productDTO.ProductId);

            if (product == null)
                return NotFound();

            product = mapper.Map<ProductDTO, Product>(productDTO);
            context.Products.Update(product);
            await context.SaveChangesAsync();
            return Ok(mapper.Map<ProductDTO>(product));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ProductDTO>> delete(int id) {
            var product = await context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (product == null)
                return NotFound();
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return Ok(mapper.Map<ProductDTO>(product));
        }
    }
}
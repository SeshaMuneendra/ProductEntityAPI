using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductEntityAPI.Data;
using ProductEntityAPI.Models;

namespace ProductEntityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<List<ProductEntity>>> Get()
        {
            return Ok(await _context.products.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<ProductEntity>>> Add(ProductEntity productEntity)
        {
            _context.products.Add(productEntity);
            await _context.SaveChangesAsync();
            return Ok(await _context.products.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<ProductEntity>>> Update(ProductEntity request)
        {
            var dbtest = await _context.products.FindAsync(request.Id);
            if (dbtest == null)
                return BadRequest("Product not found.");

            dbtest.Name = request.Name;
            dbtest.Price = request.Price;

            await _context.SaveChangesAsync();

            return Ok(await _context.products.ToListAsync());
        }

        [HttpDelete("{id}")]


        public async Task<ActionResult<List<ProductEntity>>> Delete(int id)
        {
            var dbtest = await _context.products.FindAsync(id);
            if (dbtest == null)
                return BadRequest("Product not found.");

            _context.products.Remove(dbtest);
            await _context.SaveChangesAsync();

            return Ok(await _context.products.ToListAsync());
        }
    }
}

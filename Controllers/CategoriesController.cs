using ApiTest.DAL;
using ApiTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly AppDbContext context;
        public CategoriesController(AppDbContext _context)
        {
            context = _context;
        }
        public IActionResult Get()
        { 
            return Ok(context.Categories.Include(c=> c.Products));
        }

        [HttpGet("{id}/{take}")]
        public async Task<IActionResult> Get(int id, int take)
        {
            var category = await context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c=> c.Id==id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category.Products.Take(take));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("category is not valid");
            }
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return Created($"/api/categories/{category.Id}",category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return Ok("Deleted category");
        }

    }
}
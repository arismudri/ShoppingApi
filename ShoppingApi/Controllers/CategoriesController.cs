using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingApi;
using ShoppingApi.ModelsView;

namespace ShoppingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ShoppingDBContext context;
        private readonly IMapper mapper;

        public CategoriesController(ShoppingDBContext _context, IMapper _mapper)
        {
            this.context = _context;
            this.mapper = _mapper;
        }

        // GET: api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<JoinCategoryDTO>> GetCategories()
        {
            var entity = context.Categories.Include(a=> a.Items).ToList();

            if (entity == null)
            {
                return null;
            }

            var data = mapper.Map<List<JoinCategoryDTO>>(entity);
            return Ok( data );
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<JoinCategoryDTO> GetCategory(int id)
        {
            var entity = context.Categories.Include(a=> a.Items).SingleOrDefault(c => c.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            var data = mapper.Map<JoinCategoryDTO>(entity);

            return Ok(data);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            context.Entry(category).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            context.Categories.Add(category);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var category = await context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            context.Categories.Remove(category);
            await context.SaveChangesAsync();

            return category;
        }

        private bool CategoryExists(int id)
        {
            return context.Categories.Any(e => e.Id == id);
        }
    }
}

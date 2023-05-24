using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FamilyFastFoodSimpleApi.Data;
using FamilyFastFoodSimpleApi.DataModels;

namespace FamilyFastFoodSimpleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuisinesController : ControllerBase
    {
        private readonly FamilyFastFoodSimpleApiContext _context;

        public CuisinesController(FamilyFastFoodSimpleApiContext context)
        {
            _context = context;
        }

        // GET: api/Cuisines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuisines>>> GetCuisines()
        {
          if (_context.Cuisines == null)
          {
              return NotFound();
          }
            return await _context.Cuisines.ToListAsync();
        }

        // GET: api/Cuisines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuisines>> GetCuisines(int id)
        {
          if (_context.Cuisines == null)
          {
              return NotFound();
          }
            var cuisines = await _context.Cuisines.FindAsync(id);

            if (cuisines == null)
            {
                return NotFound();
            }

            return cuisines;
        }

        // PUT: api/Cuisines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuisines(int id, Cuisines cuisines)
        {
            if (id != cuisines.CuisinesId)
            {
                return BadRequest();
            }

            _context.Entry(cuisines).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuisinesExists(id))
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

        // POST: api/Cuisines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cuisines>> PostCuisines(Cuisines cuisines)
        {
          if (_context.Cuisines == null)
          {
              return Problem("Entity set 'FamilyFastFoodSimpleApiContext.Cuisines'  is null.");
          }
            _context.Cuisines.Add(cuisines);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCuisines", new { id = cuisines.CuisinesId }, cuisines);
        }

        // DELETE: api/Cuisines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuisines(int id)
        {
            if (_context.Cuisines == null)
            {
                return NotFound();
            }
            var cuisines = await _context.Cuisines.FindAsync(id);
            if (cuisines == null)
            {
                return NotFound();
            }

            _context.Cuisines.Remove(cuisines);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CuisinesExists(int id)
        {
            return (_context.Cuisines?.Any(e => e.CuisinesId == id)).GetValueOrDefault();
        }
    }
}

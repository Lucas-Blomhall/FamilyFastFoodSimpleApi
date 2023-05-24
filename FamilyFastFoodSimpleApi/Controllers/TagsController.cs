﻿using System;
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
    public class TagsController : ControllerBase
    {
        private readonly FamilyFastFoodSimpleApiContext _context;

        public TagsController(FamilyFastFoodSimpleApiContext context)
        {
            _context = context;
        }

        // GET: api/Tags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tags>>> GetTags()
        {
          if (_context.Tags == null)
          {
              return NotFound();
          }
            return await _context.Tags.ToListAsync();
        }

        // GET: api/Tags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tags>> GetTags(int id)
        {
          if (_context.Tags == null)
          {
              return NotFound();
          }
            var tags = await _context.Tags.FindAsync(id);

            if (tags == null)
            {
                return NotFound();
            }

            return tags;
        }

        // PUT: api/Tags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTags(int id, Tags tags)
        {
            if (id != tags.TagsId)
            {
                return BadRequest();
            }

            _context.Entry(tags).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagsExists(id))
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

        // POST: api/Tags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tags>> PostTags(Tags tags)
        {
          if (_context.Tags == null)
          {
              return Problem("Entity set 'FamilyFastFoodSimpleApiContext.Tags'  is null.");
          }
            _context.Tags.Add(tags);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTags", new { id = tags.TagsId }, tags);
        }

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTags(int id)
        {
            if (_context.Tags == null)
            {
                return NotFound();
            }
            var tags = await _context.Tags.FindAsync(id);
            if (tags == null)
            {
                return NotFound();
            }

            _context.Tags.Remove(tags);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TagsExists(int id)
        {
            return (_context.Tags?.Any(e => e.TagsId == id)).GetValueOrDefault();
        }
    }
}

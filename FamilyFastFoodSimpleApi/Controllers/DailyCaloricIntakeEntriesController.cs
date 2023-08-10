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
    public class DailyCaloricIntakeEntriesController : ControllerBase
    {
        private readonly FamilyFastFoodSimpleApiContext _context;

        public DailyCaloricIntakeEntriesController(FamilyFastFoodSimpleApiContext context)
        {
            _context = context;
        }

        // GET: api/DailyCaloricIntakeEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyCaloricIntakeEntry>>> GetDailyCaloricIntakeEntry()
        {
          if (_context.DailyCaloricIntakeEntry == null)
          {
              return NotFound();
          }
            return await _context.DailyCaloricIntakeEntry.ToListAsync();
        }

        // GET: api/DailyCaloricIntakeEntries/5/{userId}/{month}/{year}
        [HttpGet("ForUser/{userId}/{month}/{year}")]
        public async Task<ActionResult<IEnumerable<DailyCaloricIntakeEntry>>> GetCaloricEntriesForUser(int userId, int month, int year)
        {
            var entries = _context.DailyCaloricIntakeEntry
              .Where(entry => entry.UserId == userId && entry.Date.Month == month && entry.Date.Year == year)
              .ToList();

            if (!entries.Any())
            {
                return NotFound();
            }

            return entries;
        }

        // PUT: api/DailyCaloricIntakeEntries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyCaloricIntakeEntry(int id, DailyCaloricIntakeEntry dailyCaloricIntakeEntry)
        {
            if (id != dailyCaloricIntakeEntry.DailyCaloricIntakeEntryId)
            {
                return BadRequest();
            }

            _context.Entry(dailyCaloricIntakeEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailyCaloricIntakeEntryExists(id))
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

        // POST: api/DailyCaloricIntakeEntries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DailyCaloricIntakeEntry>> PostDailyCaloricIntakeEntry(DailyCaloricIntakeEntry dailyCaloricIntakeEntry)
        {
          if (_context.DailyCaloricIntakeEntry == null)
          {
              return Problem("Entity set 'FamilyFastFoodSimpleApiContext.DailyCaloricIntakeEntry'  is null.");
          }

            var userId = dailyCaloricIntakeEntry.UserId; // Assuming you have UserId in your entry model.

            var today = DateTime.Today;
            var existingEntryForToday = await _context.DailyCaloricIntakeEntry
                .FirstOrDefaultAsync(e => e.UserId == userId && e.Date.Date == today);

            if (existingEntryForToday != null)
            {
                // Find the next day without an entry.
                var nextAvailableDate = today.AddDays(1);
                while (_context.DailyCaloricIntakeEntry.Any(e => e.UserId == userId && e.Date.Date == nextAvailableDate))
                {
                    nextAvailableDate = nextAvailableDate.AddDays(1);
                }

                dailyCaloricIntakeEntry.Date = nextAvailableDate;
            }
            else
            {
                dailyCaloricIntakeEntry.Date = today;
            }

            _context.DailyCaloricIntakeEntry.Add(dailyCaloricIntakeEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDailyCaloricIntakeEntry", new { id = dailyCaloricIntakeEntry.DailyCaloricIntakeEntryId }, dailyCaloricIntakeEntry);
        }

        // DELETE: api/DailyCaloricIntakeEntries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDailyCaloricIntakeEntry(int id)
        {
            if (_context.DailyCaloricIntakeEntry == null)
            {
                return NotFound();
            }
            var dailyCaloricIntakeEntry = await _context.DailyCaloricIntakeEntry.FindAsync(id);
            if (dailyCaloricIntakeEntry == null)
            {
                return NotFound();
            }

            _context.DailyCaloricIntakeEntry.Remove(dailyCaloricIntakeEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DailyCaloricIntakeEntryExists(int id)
        {
            return (_context.DailyCaloricIntakeEntry?.Any(e => e.DailyCaloricIntakeEntryId == id)).GetValueOrDefault();
        }
    }
}

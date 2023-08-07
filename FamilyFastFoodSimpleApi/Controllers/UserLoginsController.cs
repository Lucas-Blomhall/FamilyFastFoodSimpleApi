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
    public class UserLoginsController : ControllerBase
    {
        private readonly FamilyFastFoodSimpleApiContext _context;

        public UserLoginsController(FamilyFastFoodSimpleApiContext context)
        {
            _context = context;
        }

        // GET: api/UserLogins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLogins>>> GetUserLogins()
        {
          if (_context.UserLogins == null)
          {
              return NotFound();
          }
            return await _context.UserLogins.ToListAsync();
        }

        // GET: api/UserLogins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserLogins>> GetUserLogins(int id)
        {
          if (_context.UserLogins == null)
          {
              return NotFound();
          }
            var userLogins = await _context.UserLogins.FindAsync(id);

            if (userLogins == null)
            {
                return NotFound();
            }

            return userLogins;
        }

        // PUT: api/UserLogins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserLogins(int id, UserLogins userLogins)
        {
            if (id != userLogins.UserLoginsId)
            {
                return BadRequest();
            }

            _context.Entry(userLogins).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLoginsExists(id))
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

        // POST: api/UserLogins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserLogins>> PostUserLogins(UserLogins userLogins)
        {
          if (_context.UserLogins == null)
          {
              return Problem("Entity set 'FamilyFastFoodSimpleApiContext.UserLogins'  is null.");
          }
            _context.UserLogins.Add(userLogins);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserLogins", new { id = userLogins.UserLoginsId }, userLogins);
        }

        // DELETE: api/UserLogins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserLogins(int id)
        {
            if (_context.UserLogins == null)
            {
                return NotFound();
            }
            var userLogins = await _context.UserLogins.FindAsync(id);
            if (userLogins == null)
            {
                return NotFound();
            }

            _context.UserLogins.Remove(userLogins);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserLoginsExists(int id)
        {
            return (_context.UserLogins?.Any(e => e.UserLoginsId == id)).GetValueOrDefault();
        }
    }
}

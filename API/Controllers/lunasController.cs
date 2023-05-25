using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca_De_Clases;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class lunasController : ControllerBase
    {
        private readonly dbContext _context;

        public lunasController(dbContext context)
        {
            _context = context;
        }

        // GET: api/lunas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<luna>>> Getluna()
        {
          if (_context.luna == null)
          {
              return NotFound();
          }
            return await _context.luna.
                Include(planet => planet.planeta_luna).
                ToListAsync();
        }

        // GET: api/lunas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<luna>> Getluna(string id)
        {
          if (_context.luna == null)
          {
              return NotFound();
          }
            var luna = _context.luna.
                Include(planet => planet.planeta_luna).
                First(moon => moon.codigo_luna == id);

            if (luna == null)
            {
                return NotFound();
            }

            return luna;
        }

        // PUT: api/lunas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putluna(string id, luna luna)
        {
            if (id != luna.codigo_luna)
            {
                return BadRequest();
            }

            _context.Entry(luna).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!lunaExists(id))
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

        // POST: api/lunas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<luna>> Postluna(luna luna)
        {
          if (_context.luna == null)
          {
              return Problem("Entity set 'dbContext.luna'  is null.");
          }
            _context.luna.Add(luna);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (lunaExists(luna.codigo_luna))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getluna", new { id = luna.codigo_luna }, luna);
        }

        // DELETE: api/lunas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteluna(string id)
        {
            if (_context.luna == null)
            {
                return NotFound();
            }
            var luna = await _context.luna.FindAsync(id);
            if (luna == null)
            {
                return NotFound();
            }

            _context.luna.Remove(luna);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool lunaExists(string id)
        {
            return (_context.luna?.Any(e => e.codigo_luna == id)).GetValueOrDefault();
        }
    }
}

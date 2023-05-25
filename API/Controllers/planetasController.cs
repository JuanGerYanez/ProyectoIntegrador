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
    public class planetasController : ControllerBase
    {
        private readonly dbContext _context;

        public planetasController(dbContext context)
        {
            _context = context;
        }

        // GET: api/planetas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<planeta>>> Getplaneta()
        {
          if (_context.planeta == null)
          {
              return NotFound();
          }
            return await _context.planeta.
                Include(moon => moon.lunas_planeta).
                Include(galaxi => galaxi.galaxia_planeta).
                ToListAsync();
        }

        // GET: api/planetas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<planeta>> Getplaneta(string id)
        {
          if (_context.planeta == null)
          {
              return NotFound();
          }
            var planeta = _context.planeta.
                Include(moon => moon.lunas_planeta).
                Include(galaxi => galaxi.galaxia_planeta).
                First(planet => planet.codigo_planeta == id);

            if (planeta == null)
            {
                return NotFound();
            }

            return planeta;
        }

        // PUT: api/planetas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putplaneta(string id, planeta planeta)
        {
            if (id != planeta.codigo_planeta)
            {
                return BadRequest();
            }

            _context.Entry(planeta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!planetaExists(id))
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

        // POST: api/planetas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<planeta>> Postplaneta(planeta planeta)
        {
          if (_context.planeta == null)
          {
              return Problem("Entity set 'dbContext.planeta'  is null.");
          }
            _context.planeta.Add(planeta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (planetaExists(planeta.codigo_planeta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getplaneta", new { id = planeta.codigo_planeta }, planeta);
        }

        // DELETE: api/planetas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteplaneta(string id)
        {
            if (_context.planeta == null)
            {
                return NotFound();
            }
            var planeta = await _context.planeta.FindAsync(id);
            if (planeta == null)
            {
                return NotFound();
            }

            _context.planeta.Remove(planeta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool planetaExists(string id)
        {
            return (_context.planeta?.Any(e => e.codigo_planeta == id)).GetValueOrDefault();
        }
    }
}

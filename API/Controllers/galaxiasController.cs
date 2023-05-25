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
    public class galaxiasController : ControllerBase
    {
        private readonly dbContext _context;

        public galaxiasController(dbContext context)
        {
            _context = context;
        }

        // GET: api/galaxias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<galaxia>>> Getgalaxia()
        {
          if (_context.galaxia == null)
          {
              return NotFound();
          }
            return await _context.galaxia.Include(planet => planet.planetas_galaxia).ToListAsync();
        }

        // GET: api/galaxias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<galaxia>> Getgalaxia(string id)
        {
          if (_context.galaxia == null)
          {
              return NotFound();
          }
            var galaxia = _context.galaxia.
                Include(planet => planet.planetas_galaxia).
                First(galaxi => galaxi.codigo_galaxia == id);

            if (galaxia == null)
            {
                return NotFound();
            }

            return galaxia;
        }

        // PUT: api/galaxias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgalaxia(string id, galaxia galaxia)
        {
            if (id != galaxia.codigo_galaxia)
            {
                return BadRequest();
            }

            _context.Entry(galaxia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!galaxiaExists(id))
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

        // POST: api/galaxias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<galaxia>> Postgalaxia(galaxia galaxia)
        {
          if (_context.galaxia == null)
          {
              return Problem("Entity set 'dbContext.galaxia'  is null.");
          }
            _context.galaxia.Add(galaxia);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (galaxiaExists(galaxia.codigo_galaxia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getgalaxia", new { id = galaxia.codigo_galaxia }, galaxia);
        }

        // DELETE: api/galaxias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletegalaxia(string id)
        {
            if (_context.galaxia == null)
            {
                return NotFound();
            }
            var galaxia = await _context.galaxia.FindAsync(id);
            if (galaxia == null)
            {
                return NotFound();
            }

            _context.galaxia.Remove(galaxia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool galaxiaExists(string id)
        {
            return (_context.galaxia?.Any(e => e.codigo_galaxia == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalBrazilianHolidays.Data;
using NationalBrazilianHolidays.Model;

namespace NationalBrazilianHolidays.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContinentesController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public ContinentesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Continentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Continente>>> GetContinentes()
        {
          if (_context.Continentes == null)
          {
              return NotFound();
          }
            return await _context.Continentes.ToListAsync();
        }

        // GET: api/Continentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Continente>> GetContinente(long id)
        {
          if (_context.Continentes == null)
          {
              return NotFound();
          }
            var continente = await _context.Continentes.FindAsync(id);

            if (continente == null)
            {
                return NotFound();
            }

            return continente;
        }

        // PUT: api/Continentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContinente(long id, Continente continente)
        {
            if (id != continente.Id)
            {
                return BadRequest();
            }

            _context.Entry(continente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContinenteExists(id))
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

        // POST: api/Continentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Continente>> PostContinente(Continente continente)
        {
          if (_context.Continentes == null)
          {
              return Problem("Entity set 'DataBaseContext.Continentes'  is null.");
          }
            _context.Continentes.Add(continente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContinente", new { id = continente.Id }, continente);
        }

        private bool ContinenteExists(long id)
        {
            return (_context.Continentes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

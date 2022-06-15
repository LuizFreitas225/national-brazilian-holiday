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
    public class FeriadosController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public FeriadosController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Feriados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feriado>>> GetFeriados()
        {
          if (_context.Feriados == null)
          {
              return NotFound();
          }
            return await _context.Feriados.ToListAsync();
        }

        // GET: api/Feriados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feriado>> GetFeriado(long id)
        {
          if (_context.Feriados == null)
          {
              return NotFound();
          }
            var feriado = await _context.Feriados.FindAsync(id);

            if (feriado == null)
            {
                return NotFound();
            }

            return feriado;
        }

        // PUT: api/Feriados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeriado(long id, Feriado feriado)
        {
            if (id != feriado.Id)
            {
                return BadRequest();
            }

            _context.Entry(feriado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeriadoExists(id))
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

        // POST: api/Feriados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Feriado>> PostFeriado(Feriado feriado)
        {
          if (_context.Feriados == null)
          {
              return Problem("Entity set 'DataBaseContext.Feriados'  is null.");
          }
            _context.Feriados.Add(feriado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeriado", new { id = feriado.Id }, feriado);
        }

        // DELETE: api/Feriados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeriado(long id)
        {
            if (_context.Feriados == null)
            {
                return NotFound();
            }
            var feriado = await _context.Feriados.FindAsync(id);
            if (feriado == null)
            {
                return NotFound();
            }

            _context.Feriados.Remove(feriado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeriadoExists(long id)
        {
            return (_context.Feriados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

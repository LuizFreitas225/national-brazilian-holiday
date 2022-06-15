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
            return await _context.Feriados.Select(x => new Feriado() { Id = x.Id, Ano =  x.Ano ,
            Nome = x.Nome,
                Paises = x.Paises.Select(c => new Pais()
                {
                    Continente = c.Continente,
                    Id = c.Id,
                    Nome = c.Nome,
                    Sigla = c.Sigla
                }).ToList(), Data =  x.Data } ).ToListAsync();
        }

        // GET: api/Feriados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feriado>> GetFeriado(long id)
        {
          if (_context.Feriados == null)
          {
              return NotFound();
          }
            var feriado = await _context.Feriados.Where(x => id == x.Id).Select(x => new Feriado()
            {
                Id = x.Id,
                Ano = x.Ano,
                Nome = x.Nome,
                Paises = x.Paises.Select(c => new Pais()
                {
                    Continente = c.Continente,
                    Id = c.Id,
                    Nome = c.Nome,
                    Sigla = c.Sigla
                }).ToList(),
                Data = x.Data

            }).SingleAsync();

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
            List<Pais> paises = new List<Pais>();
            foreach (var pais in feriado.Paises)
            {
                paises.Add(_context.Paises.Find(pais.Id));
            }
            feriado.Ano = feriado.Data.Value.Year;
            feriado.Paises = paises;

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
          List<Pais> paises = new List<Pais>();
          foreach(var pais in feriado.Paises  )
            {
                paises.Add(_context.Paises.Find(pais.Id));
            }
            feriado.Ano = feriado.Data.Value.Year;
            feriado.Paises = paises;
            _context.Feriados.Add(feriado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeriado", new { id = feriado.Id }, feriado);
        }

        private bool FeriadoExists(long id)
        {
            return (_context.Feriados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

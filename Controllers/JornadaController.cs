using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gotohnbackend.Models;

namespace gotohnbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JornadaController : ControllerBase
    {
        private readonly gotoTripContext _context;

        public JornadaController(gotoTripContext context)
        {
            _context = context;
        }

        // GET: api/Jornada
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jornada>>> GetJornada()
        {
            return await _context.Jornada.ToListAsync();
        }

        // GET: api/Jornada/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jornada>> GetJornada(int id)
        {
            var jornada = await _context.Jornada.FindAsync(id);

            if (jornada == null)
            {
                return NotFound();
            }

            return jornada;
        }

        // PUT: api/Jornada/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJornada(int id, Jornada jornada)
        {
            if (id != jornada.Jornadaid)
            {
                return BadRequest();
            }

            _context.Entry(jornada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JornadaExists(id))
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

        // POST: api/Jornada
        [HttpPost]
        public async Task<ActionResult<Jornada>> PostJornada(Jornada jornada)
        {
            _context.Jornada.Add(jornada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJornada", new { id = jornada.Jornadaid }, jornada);
        }

        // DELETE: api/Jornada/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Jornada>> DeleteJornada(int id)
        {
            var jornada = await _context.Jornada.FindAsync(id);
            if (jornada == null)
            {
                return NotFound();
            }

            _context.Jornada.Remove(jornada);
            await _context.SaveChangesAsync();

            return jornada;
        }

        private bool JornadaExists(int id)
        {
            return _context.Jornada.Any(e => e.Jornadaid == id);
        }
    }
}

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
    public class ItinerarioEncabezadoController : ControllerBase
    {
        private readonly gotoTripContext _context;

        public ItinerarioEncabezadoController(gotoTripContext context)
        {
            _context = context;
        }

        // GET: api/ItinerarioEncabezado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItinerarioEncabezado>>> GetItinerarioEncabezado()
        {
            return await _context.ItinerarioEncabezado.ToListAsync();
        }

        // GET: api/ItinerarioEncabezado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItinerarioEncabezado>> GetItinerarioEncabezado(int id)
        {
            var itinerarioEncabezado = await _context.ItinerarioEncabezado.FindAsync(id);

            if (itinerarioEncabezado == null)
            {
                return NotFound();
            }

            return itinerarioEncabezado;
        }

        // PUT: api/ItinerarioEncabezado/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItinerarioEncabezado(int id, ItinerarioEncabezado itinerarioEncabezado)
        {
            if (id != itinerarioEncabezado.Itinierarioid)
            {
                return BadRequest();
            }

            _context.Entry(itinerarioEncabezado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItinerarioEncabezadoExists(id))
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

        // POST: api/ItinerarioEncabezado
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ItinerarioEncabezado>> PostItinerarioEncabezado(ItinerarioEncabezado itinerarioEncabezado)
        {
            _context.ItinerarioEncabezado.Add(itinerarioEncabezado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItinerarioEncabezado", new { id = itinerarioEncabezado.Itinierarioid }, itinerarioEncabezado);
        }

        // DELETE: api/ItinerarioEncabezado/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItinerarioEncabezado>> DeleteItinerarioEncabezado(int id)
        {
            var itinerarioEncabezado = await _context.ItinerarioEncabezado.FindAsync(id);
            if (itinerarioEncabezado == null)
            {
                return NotFound();
            }

            _context.ItinerarioEncabezado.Remove(itinerarioEncabezado);
            await _context.SaveChangesAsync();

            return itinerarioEncabezado;
        }

        private bool ItinerarioEncabezadoExists(int id)
        {
            return _context.ItinerarioEncabezado.Any(e => e.Itinierarioid == id);
        }
    }
}

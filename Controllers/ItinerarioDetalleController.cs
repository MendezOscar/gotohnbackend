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
    public class ItinerarioDetalleController : ControllerBase
    {
        private readonly gotoTripContext _context;

        public ItinerarioDetalleController(gotoTripContext context)
        {
            _context = context;
        }

        // GET: api/ItinerarioDetalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItinerarioDetalle>>> GetItinerarioDetalle()
        {
            return await _context.ItinerarioDetalle.ToListAsync();
        }

        // GET: api/ItinerarioDetalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItinerarioDetalle>> GetItinerarioDetalle(int id)
        {
            var itinerarioDetalle = await _context.ItinerarioDetalle.FindAsync(id);

            if (itinerarioDetalle == null)
            {
                return NotFound();
            }

            return itinerarioDetalle;
        }

        // PUT: api/ItinerarioDetalle/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItinerarioDetalle(int id, ItinerarioDetalle itinerarioDetalle)
        {
            if (id != itinerarioDetalle.ItinerarioDetalleid)
            {
                return BadRequest();
            }

            _context.Entry(itinerarioDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItinerarioDetalleExists(id))
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

        // POST: api/ItinerarioDetalle
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ItinerarioDetalle>> PostItinerarioDetalle(ItinerarioDetalle itinerarioDetalle)
        {
            _context.ItinerarioDetalle.Add(itinerarioDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItinerarioDetalle", new { id = itinerarioDetalle.ItinerarioDetalleid }, itinerarioDetalle);
        }

        // DELETE: api/ItinerarioDetalle/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItinerarioDetalle>> DeleteItinerarioDetalle(int id)
        {
            var itinerarioDetalle = await _context.ItinerarioDetalle.FindAsync(id);
            if (itinerarioDetalle == null)
            {
                return NotFound();
            }

            _context.ItinerarioDetalle.Remove(itinerarioDetalle);
            await _context.SaveChangesAsync();

            return itinerarioDetalle;
        }

        private bool ItinerarioDetalleExists(int id)
        {
            return _context.ItinerarioDetalle.Any(e => e.ItinerarioDetalleid == id);
        }
    }
}

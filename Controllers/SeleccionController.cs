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
    public class SeleccionController : ControllerBase
    {
        private readonly gotoTripContext _context;

        public SeleccionController(gotoTripContext context)
        {
            _context = context;
        }

        // GET: api/Seleccion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seleccion>>> GetSeleccion()
        {
            return await _context.Seleccion.ToListAsync();
        }

        // GET: api/Seleccion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seleccion>> GetSeleccion(int id)
        {
            var seleccion = await _context.Seleccion.FindAsync(id);

            if (seleccion == null)
            {
                return NotFound();
            }

            return seleccion;
        }

        // PUT: api/Seleccion/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeleccion(int id, Seleccion seleccion)
        {
            if (id != seleccion.Seleccionid)
            {
                return BadRequest();
            }

            _context.Entry(seleccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeleccionExists(id))
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

        // POST: api/Seleccion
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Seleccion>> PostSeleccion(Seleccion seleccion)
        {
            _context.Seleccion.Add(seleccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeleccion", new { id = seleccion.Seleccionid }, seleccion);
        }

        // DELETE: api/Seleccion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Seleccion>> DeleteSeleccion(int id)
        {
            var seleccion = await _context.Seleccion.FindAsync(id);
            if (seleccion == null)
            {
                return NotFound();
            }

            _context.Seleccion.Remove(seleccion);
            await _context.SaveChangesAsync();

            return seleccion;
        }

        private bool SeleccionExists(int id)
        {
            return _context.Seleccion.Any(e => e.Seleccionid == id);
        }
    }
}

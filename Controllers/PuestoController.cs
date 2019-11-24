using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using svpsbackend.Models;

namespace svpsbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestoController : ControllerBase
    {
        private readonly svpsdbContext _context;

        public PuestoController(svpsdbContext context)
        {
            _context = context;
        }

        // GET: api/Puesto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Puesto>>> GetPuesto()
        {
            return await _context.Puesto.ToListAsync();
        }

        // GET: api/Puesto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Puesto>> GetPuesto(int id)
        {
            var puesto = await _context.Puesto.FindAsync(id);

            if (puesto == null)
            {
                return NotFound();
            }

            return puesto;
        }

        // PUT: api/Puesto/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuesto(int id, Puesto puesto)
        {
            if (id != puesto.PuestoId)
            {
                return BadRequest();
            }

            _context.Entry(puesto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuestoExists(id))
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

        // POST: api/Puesto
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Puesto>> PostPuesto(Puesto puesto)
        {
            _context.Puesto.Add(puesto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPuesto", new { id = puesto.PuestoId }, puesto);
        }

        // DELETE: api/Puesto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Puesto>> DeletePuesto(int id)
        {
            var puesto = await _context.Puesto.FindAsync(id);
            if (puesto == null)
            {
                return NotFound();
            }

            _context.Puesto.Remove(puesto);
            await _context.SaveChangesAsync();

            return puesto;
        }

        private bool PuestoExists(int id)
        {
            return _context.Puesto.Any(e => e.PuestoId == id);
        }
    }
}

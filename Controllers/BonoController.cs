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
    public class BonoController : ControllerBase
    {
        private readonly svpsdbContext _context;

        public BonoController(svpsdbContext context)
        {
            _context = context;
        }

        // GET: api/Bono
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bono>>> GetBono()
        {
            return await _context.Bono.ToListAsync();
        }

        // GET: api/Bono/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bono>> GetBono(int id)
        {
            var bono = await _context.Bono.FindAsync(id);

            if (bono == null)
            {
                return NotFound();
            }

            return bono;
        }

        [HttpGet("{planilla}/{empleado}")]
        public async Task<ActionResult<IEnumerable<Bono>>> GetBonoByPlanilla(int planilla, int empleado)
        {
            var bonos = await _context.Bono.Where(x => x.PlanillaId == planilla && x.EmpleadoId == empleado).ToListAsync();

            if (bonos == null)
            {
                return NotFound();
            }

            return bonos;
        }

        // PUT: api/Bono/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBono(int id, Bono bono)
        {
            if (id != bono.BonoId)
            {
                return BadRequest();
            }

            _context.Entry(bono).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BonoExists(id))
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

        // POST: api/Bono
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Bono>> PostBono(Bono bono)
        {
            _context.Bono.Add(bono);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBono", new { id = bono.BonoId }, bono);
        }

        // DELETE: api/Bono/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bono>> DeleteBono(int id)
        {
            var bono = await _context.Bono.FindAsync(id);
            if (bono == null)
            {
                return NotFound();
            }

            _context.Bono.Remove(bono);
            await _context.SaveChangesAsync();

            return bono;
        }

        private bool BonoExists(int id)
        {
            return _context.Bono.Any(e => e.BonoId == id);
        }
    }
}

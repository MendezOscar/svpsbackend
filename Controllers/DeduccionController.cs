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
    public class DeduccionController : ControllerBase
    {
        private readonly svpsdbContext _context;

        public DeduccionController(svpsdbContext context)
        {
            _context = context;
        }

        // GET: api/Deduccion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deduccion>>> GetDeduccion()
        {
            return await _context.Deduccion.ToListAsync();
        }

        [HttpGet("{planilla}/{empleado}")]
        public async Task<ActionResult<IEnumerable<Deduccion>>> GetBonoByPlanilla(int planilla, int empleado)
        {
            var deduccion = await _context.Deduccion.Where(x => x.PlanillaId == planilla && x.EmpleadoId == empleado).ToListAsync();

            if (deduccion == null)
            {
                return NotFound();
            }

            return deduccion;
        }

        // GET: api/Deduccion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deduccion>> GetDeduccion(int id)
        {
            var deduccion = await _context.Deduccion.FindAsync(id);

            if (deduccion == null)
            {
                return NotFound();
            }

            return deduccion;
        }

        // PUT: api/Deduccion/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeduccion(int id, Deduccion deduccion)
        {
            if (id != deduccion.DeduccionId)
            {
                return BadRequest();
            }

            _context.Entry(deduccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeduccionExists(id))
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

        // POST: api/Deduccion
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Deduccion>> PostDeduccion(Deduccion deduccion)
        {
            _context.Deduccion.Add(deduccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeduccion", new { id = deduccion.DeduccionId }, deduccion);
        }

        // DELETE: api/Deduccion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Deduccion>> DeleteDeduccion(int id)
        {
            var deduccion = await _context.Deduccion.FindAsync(id);
            if (deduccion == null)
            {
                return NotFound();
            }

            _context.Deduccion.Remove(deduccion);
            await _context.SaveChangesAsync();

            return deduccion;
        }

        private bool DeduccionExists(int id)
        {
            return _context.Deduccion.Any(e => e.DeduccionId == id);
        }
    }
}

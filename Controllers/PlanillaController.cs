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
    public class PlanillaController : ControllerBase
    {
        private readonly svpsdbContext _context;

        public PlanillaController(svpsdbContext context)
        {
            _context = context;
        }

        // GET: api/Planilla
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planilla>>> GetPlanilla()
        {
            return await _context.Planilla.ToListAsync();
        }

        // GET: api/Planilla/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Planilla>> GetPlanilla(int id)
        {
            var planilla = await _context.Planilla.FindAsync(id);

            if (planilla == null)
            {
                return NotFound();
            }

            return planilla;
        }

        [HttpGet("empleado/{empleado}")]
        public async Task<ActionResult<IEnumerable<Planilla>>> GetPlanillaByEmpleado(int empleado)
        {
            Console.WriteLine("hola");
            var planilla = await _context.Planilla.Where(x => x.Empleadoid == empleado).ToListAsync();;

            if (planilla == null)
            {
                return NotFound();
            }

            return planilla;
        }

        // PUT: api/Planilla/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanilla(int id, Planilla planilla)
        {
            if (id != planilla.PanillaId)
            {
                return BadRequest();
            }

            _context.Entry(planilla).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanillaExists(id))
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

        // POST: api/Planilla
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Planilla>> PostPlanilla(Planilla planilla)
        {
            _context.Planilla.Add(planilla);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanilla", new { id = planilla.PanillaId }, planilla);
        }

        // DELETE: api/Planilla/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Planilla>> DeletePlanilla(int id)
        {
            var planilla = await _context.Planilla.FindAsync(id);
            if (planilla == null)
            {
                return NotFound();
            }

            _context.Planilla.Remove(planilla);
            await _context.SaveChangesAsync();

            return planilla;
        }

        private bool PlanillaExists(int id)
        {
            return _context.Planilla.Any(e => e.PanillaId == id);
        }
    }
}

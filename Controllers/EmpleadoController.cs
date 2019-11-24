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
    public class EmpleadoController : ControllerBase
    {
        private readonly svpsdbContext _context;

        public EmpleadoController(svpsdbContext context)
        {
            _context = context;
        }

        // GET: api/Empleado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleado()
        {
            return await _context.Empleado.ToListAsync();
        }

        // GET: api/Empleado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
            var empleado = await _context.Empleado.FindAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        [HttpGet("by-sexo/{sexo}")]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleadoBySexo(string sexo)
        {
            var deduccion = await _context.Empleado.Where(x => x.Sexo == sexo).ToListAsync();

            if (deduccion == null)
            {
                return NotFound();
            }

            return deduccion;
        }

        [HttpGet("by-salario/{salario}")]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleadoBySalario(float salario)
        {
            var deduccion = await _context.Empleado.Where(x => x.Salario == salario).ToListAsync();

            if (deduccion == null)
            {
                return NotFound();
            }

            return deduccion;
        }

        [HttpGet("by-puesto/{puesto}")]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleadoByMestro(int puesto)
        {
            var deduccion = await _context.Empleado.Where(x => x.CargoId == puesto).ToListAsync();

            if (deduccion == null)
            {
                return NotFound();
            }

            return deduccion;
        }

        // PUT: api/Empleado/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.EmpleadoId)
            {
                return BadRequest();
            }

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
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

        // POST: api/Empleado
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            _context.Empleado.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpleado", new { id = empleado.EmpleadoId }, empleado);
        }

        // DELETE: api/Empleado/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Empleado>> DeleteEmpleado(int id)
        {
            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleado.Remove(empleado);
            await _context.SaveChangesAsync();

            return empleado;
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleado.Any(e => e.EmpleadoId == id);
        }
    }
}

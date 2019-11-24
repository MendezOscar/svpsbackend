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
    public class PermisosController : ControllerBase
    {
        private readonly svpsdbContext _context;

        public PermisosController(svpsdbContext context)
        {
            _context = context;
        }

        // GET: api/Permisos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Permisos>>> GetPermisos()
        {
            return await _context.Permisos.ToListAsync();
        }

        // GET: api/Permisos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Permisos>> GetPermisos(int id)
        {
            var permisos = await _context.Permisos.FindAsync(id);

            if (permisos == null)
            {
                return NotFound();
            }

            return permisos;
        }

        // PUT: api/Permisos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermisos(int id, Permisos permisos)
        {
            if (id != permisos.PermisoId)
            {
                return BadRequest();
            }

            _context.Entry(permisos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermisosExists(id))
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

        // POST: api/Permisos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Permisos>> PostPermisos(Permisos permisos)
        {
            _context.Permisos.Add(permisos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPermisos", new { id = permisos.PermisoId }, permisos);
        }

        // DELETE: api/Permisos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Permisos>> DeletePermisos(int id)
        {
            var permisos = await _context.Permisos.FindAsync(id);
            if (permisos == null)
            {
                return NotFound();
            }

            _context.Permisos.Remove(permisos);
            await _context.SaveChangesAsync();

            return permisos;
        }

        private bool PermisosExists(int id)
        {
            return _context.Permisos.Any(e => e.PermisoId == id);
        }
    }
}

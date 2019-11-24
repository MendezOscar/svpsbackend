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
    public class PermisosxusuarioController : ControllerBase
    {
        private readonly svpsdbContext _context;

        public PermisosxusuarioController(svpsdbContext context)
        {
            _context = context;
        }

        // GET: api/Permisosxusuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Permisosxusuario>>> GetPermisosxusuario()
        {
            return await _context.Permisosxusuario.ToListAsync();
        }

        // GET: api/Permisosxusuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Permisosxusuario>> GetPermisosxusuario(int id)
        {
            var permisosxusuario = await _context.Permisosxusuario.FindAsync(id);

            if (permisosxusuario == null)
            {
                return NotFound();
            }

            return permisosxusuario;
        }

        // PUT: api/Permisosxusuario/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermisosxusuario(int id, Permisosxusuario permisosxusuario)
        {
            if (id != permisosxusuario.Permisoxusuario)
            {
                return BadRequest();
            }

            _context.Entry(permisosxusuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermisosxusuarioExists(id))
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

        // POST: api/Permisosxusuario
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Permisosxusuario>> PostPermisosxusuario(Permisosxusuario permisosxusuario)
        {
            _context.Permisosxusuario.Add(permisosxusuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPermisosxusuario", new { id = permisosxusuario.Permisoxusuario }, permisosxusuario);
        }

        // DELETE: api/Permisosxusuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Permisosxusuario>> DeletePermisosxusuario(int id)
        {
            var permisosxusuario = await _context.Permisosxusuario.FindAsync(id);
            if (permisosxusuario == null)
            {
                return NotFound();
            }

            _context.Permisosxusuario.Remove(permisosxusuario);
            await _context.SaveChangesAsync();

            return permisosxusuario;
        }

        private bool PermisosxusuarioExists(int id)
        {
            return _context.Permisosxusuario.Any(e => e.Permisoxusuario == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S4_Progra_Web.Server.Data;
using S4_Progra_Web.Shared.Modelos;

namespace S4_Progra_Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorsController : ControllerBase
    {
        private readonly DBCubesContext _context;

        public ProveedorsController(DBCubesContext context)
        {
            _context = context;
        }

        // GET: api/Proveedors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> GetProveedor()
        {
          if (_context.Proveedor == null)
          {
              return NotFound();
          }
            return await _context.Proveedor.Include(c => c.Cubos).ToListAsync();
        }

        // GET: api/Proveedors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Proveedor>>> GetProveedor(int id)
        {
          if (_context.Proveedor == null)
          {
              return NotFound();
          }
            var proveedor = await _context.Proveedor.Where(x => x.IdProveedor == id).Include(c => c.Cubos).ToListAsync();

            if (proveedor == null)
            {
                return NotFound();
            }

            return proveedor;
        }

        // PUT: api/Proveedors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedor(int id, Proveedor proveedor)
        {
            if (id != proveedor.IdProveedor)
            {
                return BadRequest();
            }

            _context.Entry(proveedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorExists(id))
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

        // POST: api/Proveedors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proveedor>> PostProveedor(Proveedor proveedor)
        {
          if (_context.Proveedor == null)
          {
              return Problem("Entity set 'DBCubesContext.Proveedor'  is null.");
          }
            _context.Proveedor.Add(proveedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProveedor", new { id = proveedor.IdProveedor }, proveedor);
        }
        /*
        // POST: api/Proveedors/id/cubos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}/cubos")]
        public async Task<ActionResult<Proveedor>> PostCubosProveedor(int id, List<Cube> cubos)
        {
            if (cubos == null)
            {
                return Problem("Lista de Cubos nula");
            }
            var proveedor = await _context.Proveedor.FindAsync(id);
            if(proveedor != null)
            {
                proveedor.Cubos = cubos;
            }
            await _context.SaveChangesAsync();
            return NoContent();
        }
        */

        // DELETE: api/Proveedors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedor(int id)
        {
            if (_context.Proveedor == null)
            {
                return NotFound();
            }
            var proveedor = await _context.Proveedor.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            _context.Proveedor.Remove(proveedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProveedorExists(int id)
        {
            return (_context.Proveedor?.Any(e => e.IdProveedor == id)).GetValueOrDefault();
        }
    }
}

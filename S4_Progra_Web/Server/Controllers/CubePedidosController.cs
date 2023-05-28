using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using S4_Progra_Web.Server.Data;
using S4_Progra_Web.Shared.Modelos;

namespace S4_Progra_Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CubePedidosController : ControllerBase
    {
        private readonly DBCubesContext _context;

        public CubePedidosController(DBCubesContext context)
        {
            _context = context;
        }

        // GET: api/CubePedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CubePedidos>>> GetCubePedidos()
        {
            if (_context.CubePedidos == null)
            {
                return NotFound();
            }
            return await _context.CubePedidos.ToListAsync();
        }

        // GET: api/CubePedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CubePedidos>> GetCubePedidos(int id)
        {
            if (_context.CubePedidos == null)
            {
                return NotFound();
            }
            var cubePedidos = await _context.CubePedidos.FindAsync(id);

            if (cubePedidos == null)
            {
                return NotFound();
            }

            return cubePedidos;
        }

        // PUT: api/CubePedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCubePedidos(int id, CubePedidos cubePedidos)
        {
            if (id != cubePedidos.CubeId)
            {
                return BadRequest();
            }

            _context.Entry(cubePedidos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CubePedidosExists(id))
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

        // POST: api/CubePedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CubePedidos>> PostCubePedidos(CubePedidos cubePedidos)
        {
            if (_context.CubePedidos == null)
            {
                return Problem("Entity set 'DBCubesContext.CubePedidos'  is null.");
            }
            _context.CubePedidos.Add(cubePedidos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CubePedidosExists(cubePedidos.CubeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCubePedidos", new { id = cubePedidos.CubeId }, cubePedidos);
        }



        // DELETE: api/CubePedidos/5/6
        [HttpDelete("{ida1}/{ida2}")]
        public async Task<IActionResult> DeleteCubePedidos(int ida1, int ida2)
        {
            if (_context.CubePedidos == null)
            {
                return NotFound();
            }
            var entity = new CubePedidos { CubeId = ida1, PedidosId = ida2 };
            _context.CubePedidos.Attach(entity);
            _context.CubePedidos.Remove(entity);
            _context.SaveChanges();

            return NoContent();
        }

        private bool CubePedidosExists(int id)
        {
            return (_context.CubePedidos?.Any(e => e.CubeId == id)).GetValueOrDefault();
        }
    }
}

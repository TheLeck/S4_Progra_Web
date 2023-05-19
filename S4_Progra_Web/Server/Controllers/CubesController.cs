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
    public class CubesController : ControllerBase
    {
        private readonly DBCubesContext _context;

        public CubesController(DBCubesContext context)
        {
            _context = context;
        }

        // GET: api/Cubes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cube>>> GetCubes()
        {
          if (_context.Cubes == null)
          {
              return NotFound();
          }
            return await _context.Cubes.Include(c => c.ProveedorData).ToListAsync();
        }

        // GET: api/Cubes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Cube>>> GetCube(int id)
        {
          if (_context.Cubes == null)
          {
              return NotFound();
          }
            var cube = await _context.Cubes.Where(x => x.id == id).Include(c => c.ProveedorData).ToListAsync();

            if (cube == null)
            {
                return NotFound();
            }

            return cube;
        }

        // PUT: api/Cubes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCube(int id, Cube cube)
        {
            if (id != cube.id)
            {
                return BadRequest();
            }

            _context.Entry(cube).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CubeExists(id))
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

        // POST: api/Cubes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cube>> PostCube(Cube cube)
        {
          if (_context.Cubes == null)
          {
              return Problem("Entity set 'DBCubesContext.Cubes'  is null.");
          }
            _context.Cubes.Add(cube);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCube", new { id = cube.id }, cube);
        }

        // DELETE: api/Cubes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCube(int id)
        {
            if (_context.Cubes == null)
            {
                return NotFound();
            }
            var cube = await _context.Cubes.FindAsync(id);
            if (cube == null)
            {
                return NotFound();
            }

            _context.Cubes.Remove(cube);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CubeExists(int id)
        {
            return (_context.Cubes?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}

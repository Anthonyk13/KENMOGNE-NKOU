using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetC_.Data;
using ProjetC_.Models;

namespace ProjetC_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentesController : ControllerBase
    {
        private readonly ProjetC_Context _context;

        public VentesController(ProjetC_Context context)
        {
            _context = context;
        }

        // GET: api/Ventes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ventes>>> GetVentes()
        {
            return await _context.Ventes.ToListAsync();
        }

        // GET: api/Ventes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ventes>> GetVentes(int id)
        {
            var ventes = await _context.Ventes.FindAsync(id);

            if (ventes == null)
            {
                return NotFound();
            }

            return ventes;
        }

        // PUT: api/Ventes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentes(int id, Ventes ventes)
        {
            if (id != ventes.Id)
            {
                return BadRequest();
            }

            _context.Entry(ventes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentesExists(id))
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

        // POST: api/Ventes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ventes>> PostVentes(Ventes ventes)
        {
            _context.Ventes.Add(ventes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVentes", new { id = ventes.Id }, ventes);
        }

        // DELETE: api/Ventes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVentes(int id)
        {
            var ventes = await _context.Ventes.FindAsync(id);
            if (ventes == null)
            {
                return NotFound();
            }

            _context.Ventes.Remove(ventes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentesExists(int id)
        {
            return _context.Ventes.Any(e => e.Id == id);
        }
    }
}

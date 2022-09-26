using CagriMerkeziAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CagriMerkeziAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CagriDetayController : ControllerBase
    {
        private readonly CagriMerkeziContext _context;

        public CagriDetayController(CagriMerkeziContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CagriDetay>>> GetCagriDetays()
        {
            return await _context.CagriDetays.ToListAsync();
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<CagriDetay>> GetCagriDetay(int id)
        {
            var CagriDetay = await _context.CagriDetays.FindAsync(id);

            if (CagriDetay == null)
            {
                return NotFound();
            }

            return CagriDetay;
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCagriDetay(int id, CagriDetay cagriDetay)
        {
            if (id != cagriDetay.id)
            {
                return BadRequest();
            }

            _context.Entry(cagriDetay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CagriDetayExists(id))
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

        private bool CagriDetayExists(int id)
        {
            throw new NotImplementedException();
        }

       
       [HttpPost]
        public async Task<ActionResult<CagriDetay>> PostGorevTakipDetay(CagriDetay cagriDetay)
        {
            _context.CagriDetays.Add(cagriDetay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCagriDetay", new { id = cagriDetay.id }, cagriDetay);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCagriDetay(int id)
        {
            var cagriDetay = await _context.CagriDetays.FindAsync(id);
            if (cagriDetay == null)
            {
                return NotFound();
            }

            _context.CagriDetays.Remove(cagriDetay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool cagriDetayExists(int id)
        {
            return _context.CagriDetays.Any(e => e.id == id);
        }

    }
}

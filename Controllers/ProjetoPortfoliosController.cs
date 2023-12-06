using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIWedfy.Data;
using APIWedfy.Models;

namespace APIWedfy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoPortfoliosController : ControllerBase
    {
        private readonly WedfyContext _context;

        public ProjetoPortfoliosController(WedfyContext context)
        {
            _context = context;
        }

        // GET: api/ProjetoPortfolios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjetoPortfolio>>> GetProjetoPortfolios()
        {
          if (_context.ProjetoPortfolios == null)
          {
              return NotFound();
          }
            return await _context.ProjetoPortfolios.ToListAsync();
        }

        // GET: api/ProjetoPortfolios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjetoPortfolio>> GetProjetoPortfolio(int id)
        {
          if (_context.ProjetoPortfolios == null)
          {
              return NotFound();
          }
            var projetoPortfolio = await _context.ProjetoPortfolios.FindAsync(id);

            if (projetoPortfolio == null)
            {
                return NotFound();
            }

            return projetoPortfolio;
        }

        // PUT: api/ProjetoPortfolios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjetoPortfolio(int id, ProjetoPortfolio projetoPortfolio)
        {
            if (id != projetoPortfolio.IdProjetoPortfolio)
            {
                return BadRequest();
            }

            _context.Entry(projetoPortfolio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjetoPortfolioExists(id))
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

        // POST: api/ProjetoPortfolios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjetoPortfolio>> PostProjetoPortfolio(ProjetoPortfolio projetoPortfolio)
        {
          if (_context.ProjetoPortfolios == null)
          {
              return Problem("Entity set 'WedfyContext.ProjetoPortfolios'  is null.");
          }
            _context.ProjetoPortfolios.Add(projetoPortfolio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjetoPortfolio", new { id = projetoPortfolio.IdProjetoPortfolio }, projetoPortfolio);
        }

        // DELETE: api/ProjetoPortfolios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjetoPortfolio(int id)
        {
            if (_context.ProjetoPortfolios == null)
            {
                return NotFound();
            }
            var projetoPortfolio = await _context.ProjetoPortfolios.FindAsync(id);
            if (projetoPortfolio == null)
            {
                return NotFound();
            }

            _context.ProjetoPortfolios.Remove(projetoPortfolio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjetoPortfolioExists(int id)
        {
            return (_context.ProjetoPortfolios?.Any(e => e.IdProjetoPortfolio == id)).GetValueOrDefault();
        }
    }
}

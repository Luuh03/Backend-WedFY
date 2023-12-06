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
    public class ProjetosController : ControllerBase
    {
        private readonly WedfyContext _context;

        public ProjetosController(WedfyContext context)
        {
            _context = context;
        }

        // GET: api/Projetos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projeto>>> GetProjetos()
        {
          if (_context.Projetos == null)
          {
              return NotFound();
          }
            return await _context.Projetos.ToListAsync();
        }

        // GET: api/Projetos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Projeto>> GetProjeto(int id)
        {
          if (_context.Projetos == null)
          {
              return NotFound();
          }
            var projeto = await _context.Projetos.FindAsync(id);

            if (projeto == null)
            {
                return NotFound();
            }

            return projeto;
        }

        // PUT: api/Projetos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjeto(int id, Projeto projeto)
        {
            if (id != projeto.IdProjeto)
            {
                return BadRequest();
            }

            _context.Entry(projeto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjetoExists(id))
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

        // POST: api/Projetos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Projeto>> PostProjeto(Projeto projeto)
        {
          if (_context.Projetos == null)
          {
              return Problem("Entity set 'WedfyContext.Projetos'  is null.");
          }
            _context.Projetos.Add(projeto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjeto", new { id = projeto.IdProjeto }, projeto);
        }

        // DELETE: api/Projetos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjeto(int id)
        {
            if (_context.Projetos == null)
            {
                return NotFound();
            }
            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto == null)
            {
                return NotFound();
            }

            _context.Projetos.Remove(projeto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjetoExists(int id)
        {
            return (_context.Projetos?.Any(e => e.IdProjeto == id)).GetValueOrDefault();
        }
    }
}

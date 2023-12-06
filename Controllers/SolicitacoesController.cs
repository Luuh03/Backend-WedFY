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
    public class SolicitacoesController : ControllerBase
    {
        private readonly WedfyContext _context;

        public SolicitacoesController(WedfyContext context)
        {
            _context = context;
        }

        // GET: api/Solicitacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Solicitacao>>> GetSolicitacaos()
        {
          if (_context.Solicitacaos == null)
          {
              return NotFound();
          }
            return await _context.Solicitacaos.ToListAsync();
        }

        // GET: api/Solicitacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solicitacao>> GetSolicitacao(int id)
        {
          if (_context.Solicitacaos == null)
          {
              return NotFound();
          }
            var solicitacao = await _context.Solicitacaos.FindAsync(id);

            if (solicitacao == null)
            {
                return NotFound();
            }

            return solicitacao;
        }

        // PUT: api/Solicitacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolicitacao(int id, Solicitacao solicitacao)
        {
            if (id != solicitacao.IdSolicitacao)
            {
                return BadRequest();
            }

            _context.Entry(solicitacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitacaoExists(id))
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

        // POST: api/Solicitacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Solicitacao>> PostSolicitacao(Solicitacao solicitacao)
        {
          if (_context.Solicitacaos == null)
          {
              return Problem("Entity set 'WedfyContext.Solicitacaos'  is null.");
          }
            _context.Solicitacaos.Add(solicitacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolicitacao", new { id = solicitacao.IdSolicitacao }, solicitacao);
        }

        // DELETE: api/Solicitacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolicitacao(int id)
        {
            if (_context.Solicitacaos == null)
            {
                return NotFound();
            }
            var solicitacao = await _context.Solicitacaos.FindAsync(id);
            if (solicitacao == null)
            {
                return NotFound();
            }

            _context.Solicitacaos.Remove(solicitacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SolicitacaoExists(int id)
        {
            return (_context.Solicitacaos?.Any(e => e.IdSolicitacao == id)).GetValueOrDefault();
        }
    }
}

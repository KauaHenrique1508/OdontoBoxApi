using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdontoBoxApi.Data;
using OdontoBoxApi.Models;
namespace OdontoBoxApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaidaController : ControllerBase
    {
        private readonly OdontoBoxContext _context;

        public SaidaController(OdontoBoxContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Saida>>> GetSaidas()
        {
            if (_context.Saidas == null)
            {
                return Problem("Entidade Saida é nula.");
            }

            return Ok(await _context.Saidas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Saida>> GetSaidaId(int id)
        {
            if (_context.Saidas == null)
            {
                return Problem();
            }

            var saida = await _context.Saidas.FindAsync(id);
            if (saida == null)
            {
                return NotFound("ID: " + id + " não encontrado."); 
            }
            return Ok(saida);
        }

        [HttpPost]
        public async Task<ActionResult<Saida>> PostSaida(Saida saida)
        {   
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == saida.ProdutoId);

            if(produto == null)
            {
                return NotFound("Produto não encontrado");
            }

            if(produto.QuantidadeAtual < saida.Quantidade)
            {
                return BadRequest("Quantidade insuficiente em estoque");
            }

            produto.QuantidadeAtual -= saida.Quantidade;

            _context.Saidas.Add(saida);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetSaidaId", new { id = saida.Id }, saida); 
        }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<Saida>> Put(int id, Saida s)
        // {
        //     var saida = await _context.Saidas.FirstOrDefaultAsync(s => s.Id == id);

        //     if(saida == null)
        //     {
        //         return NotFound("Saída não encontrada");
        //     }

        //     var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == s.ProdutoId);

        //     if(produto == null)
        //     {
        //         return NotFound("Produto não encontrado");
        //     }

        //     var objSaida = s;

        //     _context.Entry(saida).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if(!ProdutosExists(id))
        //         {
        //           return NotFound( "ID: " + id + " não encontrado."); // Retorna 404 se o produto não existir
        //         }   
        //         else
        //         {
        //             throw; // Re-throw se for outro erro
        //         }
        //     }
        //     return NoContent(); // erro 204


        // }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var saida = await _context.Saidas.FirstOrDefaultAsync(s => s.Id == id);

            if(saida == null)
            {
                return NotFound("Saída não encontrada");
            }

            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == saida.ProdutoId);

            if(produto == null)
            {
                return NotFound("Produto não encontrado");
            }

            produto.QuantidadeAtual += saida.Quantidade;

            _context.Saidas.Remove(saida);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
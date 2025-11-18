using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdontoBoxApi.Data;

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
            
                return Problem("Entidade Saida é nula.");

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
            if(_context.Saidas == null)
            {
                return Problem("Entidade Saida é nula.");
            }
            
            _context.Saidas.Add(saida);
            
            
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetSaidaId", new { id = saida.Id }, saida); //
        }

    //     // PUT api/produtos/5
    //     [HttpPut("{id}")]
    //     public async Task<ActionResult<Produto>> Put(int id, Produto produto)
    //     {
    //         if (id != produto.Id)
    //         {
    //             return BadRequest("ID da URL diferente do ID do objeto Produto"); // Retorna 400 se o ID da rota não bater com o ID do corpo
    //         }
    //         _context.Entry(produto).State = EntityState.Modified;
    //         try
    //         {
    //             await _context.SaveChangesAsync();
    //         }
    //         catch (DbUpdateConcurrencyException)
    //         {
    //             if(!ProdutosExists(id))
    //             {
    //               return NotFound( "ID: " + id + " não encontrado."); // Retorna 404 se o produto não existir
    //             }   
    //             else
    //             {
    //                 throw; // Re-throw se for outro erro
    //             }
    //         }
    //         return NoContent(); // erro 204
    //     }
    //     // DELETE api/produtos/5
    //     [HttpDelete("{id}")]
    //     public async Task<ActionResult> DeleteProduto(int id)
    //     {
    //        if (_context.Produtos == null)
    //     {
    //         return Problem();
    //     }
    //     var produto = await _context.Produtos.FindAsync(id);
    //     if (produto == null) 
    //     {
    //         return NotFound();
    //     }

    //     _context.Produtos.Remove(produto);
    //     await _context.SaveChangesAsync();

    //     return NoContent();
    //     }
    //      private bool ProdutosExists(int id)
    // {
    //     return (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault(); //? verifica se é verdadeiro ou falso
    // }
    // }



        //create saída
        //read saída
        //delete saída
    }
}
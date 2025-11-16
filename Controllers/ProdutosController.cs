using Microsoft.AspNetCore.Mvc;
using OdontoBoxApi.Models;  
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using OdontoBoxApi.Data;


namespace OdontoBoxApi.Controllers;

[ApiController]
[Route("[controller]")]
    
    public class ProdutosController : ControllerBase
    {
        private readonly OdontoBoxContext _context;


        public ProdutosController(OdontoBoxContext context)
        {
            _context = context;
        }

        // GET: api/produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            if (_context.Produtos == null)
            
                return Problem("Entidade Produtos é nula.");

            // Retorna todos os produtos
            return Ok(await _context.Produtos.ToListAsync());
        }

        // GET api/produtos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProdutoId(int id)
        {
            if (_context.Produtos == null)
            {
                return Problem(); // Retorna 404 se não encontrar
            }
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound("ID: " + id + " não encontrado."); // Retorna 404 se não encontrar
            }
            return Ok(produto);
        }

        // POST api/produtos
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {   
            if(_context.Produtos == null)
            {
                return Problem("Entidade Produtos é nula.");
            }
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            // Retorna 201 Created com o novo objeto
            return CreatedAtAction("GetProdutoId", new { id = produto.Id }, produto); //
        }

        // PUT api/produtos/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> Put(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest("ID da URL diferente do ID do objeto Produto"); // Retorna 400 se o ID da rota não bater com o ID do corpo
            }
            _context.Entry(produto).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!ProdutosExists(id))
                {
                  return NotFound( "ID: " + id + " não encontrado."); // Retorna 404 se o produto não existir
                }   
                else
                {
                    throw; // Re-throw se for outro erro
                }
            }
            return NoContent(); // erro 204
        }
        // DELETE api/produtos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduto(int id)
        {
           if (_context.Produtos == null)
        {
            return Problem();
        }
        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null) 
        {
            return NotFound();
        }

        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();

        return NoContent();
        }
         private bool ProdutosExists(int id)
    {
        return (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault(); //? verifica se é verdadeiro ou falso
    }
    }


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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            if (_context.Produtos == null)
            
                return Problem("Entidade Produtos é nula.");

            return Ok(await _context.Produtos.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProdutoId(int id)
        {
            if (_context.Produtos == null)
            {
                return Problem(); 
            }
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound("ID: " + id + " não encontrado."); 
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {   
            if(_context.Produtos == null)
            {
                return Problem("Entidade Produtos é nula.");
            }
            
            //add coisa aqui kaua, validação se o fornecedor existe
            var fornecedorExiste = await _context.Fornecedores.FindAsync(produto.FornecedorId);
            if (fornecedorExiste == null)
            {
                return BadRequest($"Fornecedor com ID: {produto.FornecedorId} não encontrado.");
            }
            //validar se o nome n ta vazio
            if (string.IsNullOrWhiteSpace(produto.Nome))
            {
                    return BadRequest("O nome do produto é obrigatório.");
            }
                    
            
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            
            
            return CreatedAtAction("GetProdutoId", new { id = produto.Id }, produto); 
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> Put(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest("ID da URL diferente do ID do objeto Produto"); 
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
                  return NotFound( "ID: " + id + " não encontrado."); 
                }   
                else
                {
                    throw; 
                }
            }
            return NoContent(); 
        }
    
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
            
            //validacao de saida pra poder deletar, se tiver saida pra esse produto, n deixa deletar
            var saidasAssociadas = await _context.Saidas
                .Where(s => s.ProdutoId == id)
                .CountAsync();

            if (saidasAssociadas > 0)
            {
                return BadRequest($"Não é possível deletar o produto pois existem {saidasAssociadas} saída(s) associada(s) a ele.");
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool ProdutosExists(int id)
        {
            return (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }


using Microsoft.AspNetCore.Mvc;
using OdontoBoxApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using OdontoBoxApi.Data;

namespace OdontoBoxApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FornecedoresController : ControllerBase
{
    private readonly OdontoBoxContext _context;

    public FornecedoresController(OdontoBoxContext context)
    {
        _context = context;
    }
//----------------------------------------------------------------------------------
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedores()
    {
        if (_context.Fornecedores == null)
        {
            return Problem("Entidade Fornecedores é nula.");
        }

        var fornecedores = await _context.Fornecedores
         .Include(f => f.Produtos)
        //  .ThenInclude(p => p.Saidas)
         .ToListAsync();

        return Ok(fornecedores);
    }

//----------------------------------------------------------------------------------
    [HttpGet("{id}")]
    public async Task<ActionResult<Fornecedor>> GetFornecedorId(int id)
    {
        if (_context.Fornecedores == null)
        {
            return Problem("Entidade Fornecedores é nula.");
        }

        var fornecedor = await _context.Fornecedores.FindAsync(id);

        if (fornecedor == null)
        {
            return NotFound($"Fornecedor com ID: {id} não encontrado.");
        }

        return Ok(fornecedor);
    }

//----------------------------------------------------------------------------------
    [HttpPost]
    public async Task<ActionResult<Fornecedor>> PostFornecedor(Fornecedor fornecedor)
    {
        if (_context.Fornecedores == null)
        {
            return Problem("Entidade Fornecedores é nula.");
        }

        if (string.IsNullOrWhiteSpace(fornecedor.Nome))
        {
            return BadRequest("O nome do fornecedor é obrigatório.");
        }

        if (string.IsNullOrWhiteSpace(fornecedor.CNPJ))
        {
            return BadRequest("O CNPJ é obrigatório.");
        }

        if (string.IsNullOrWhiteSpace(fornecedor.Telefone))
        {
            return BadRequest("O telefone é obrigatório.");
        }
        var fornecedorExistente = await _context.Fornecedores
            .FirstOrDefaultAsync(f => f.CNPJ == fornecedor.CNPJ);

        if (fornecedorExistente != null)
        {
            return BadRequest($"Já existe um fornecedor cadastrado com o CNPJ: {fornecedor.CNPJ}");
        }

        _context.Fornecedores.Add(fornecedor);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetFornecedorId", new { id = fornecedor.Id }, fornecedor);
    }

//----------------------------------------------------------------------------------
    [HttpPut("{id}")]
    public async Task<ActionResult> PutFornecedor(int id, Fornecedor fornecedor)
    {
        if (id != fornecedor.Id)
        {
            return BadRequest("ID da URL diferente do ID do objeto Fornecedor.");
        }

        if (string.IsNullOrWhiteSpace(fornecedor.Nome))
        {
            return BadRequest("O nome do fornecedor é obrigatório.");
        }

        if (string.IsNullOrWhiteSpace(fornecedor.CNPJ))
        {
            return BadRequest("O CNPJ é obrigatório.");
        }

        if (string.IsNullOrWhiteSpace(fornecedor.Telefone))
        {
            return BadRequest("O telefone é obrigatório.");
        }

        var fornecedorExistente = await _context.Fornecedores
            .FirstOrDefaultAsync(f => f.CNPJ == fornecedor.CNPJ && f.Id != id);

        if (fornecedorExistente != null)
        {
            return BadRequest($"Já existe outro fornecedor cadastrado com o CNPJ: {fornecedor.CNPJ}");
        }

        _context.Entry(fornecedor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FornecedorExists(id))
            {
                return NotFound($"Fornecedor com ID: {id} não encontrado.");
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

//----------------------------------------------------------------------------------
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteFornecedor(int id)
    {
        if (_context.Fornecedores == null)
        {
            return Problem("Entidade Fornecedores é nula.");
        }

        var fornecedor = await _context.Fornecedores.FindAsync(id);

        if (fornecedor == null)
        {
            return NotFound($"Fornecedor com ID: {id} não encontrado.");
        }

        var produtosAssociados = await _context.Produtos
            .Where(p => p.FornecedorId == id)
            .CountAsync();

        if (produtosAssociados > 0)
        {
            return BadRequest($"Não é possível deletar o fornecedor pois existem {produtosAssociados} produto(s) associado(s) a ele.");
        }

        _context.Fornecedores.Remove(fornecedor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool FornecedorExists(int id)
    {
        return (_context.Fornecedores?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}

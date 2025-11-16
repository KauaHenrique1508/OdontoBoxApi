
using Microsoft.EntityFrameworkCore;
using OdontoBoxApi.Models;

namespace OdontoBoxApi.Data
{
    public class OdontoBoxContext : DbContext
    {
        public OdontoBoxContext(DbContextOptions<OdontoBoxContext> options) : base(options) { }

        // Mapeamento das classes para tabelas no banco de dados
        public DbSet<Produto> Produtos { get; set; }
        // ... (Adicionar DbSet para Fornecedor, Entrada, Saida)
    }
}

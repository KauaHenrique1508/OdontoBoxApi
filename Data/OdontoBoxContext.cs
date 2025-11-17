
using Microsoft.EntityFrameworkCore;
using OdontoBoxApi.Models;

namespace OdontoBoxApi.Data
{
    public class OdontoBoxContext : DbContext
    {
        public OdontoBoxContext(DbContextOptions<OdontoBoxContext> options) : base(options) { }
       
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Saida> Saidas { get; set; }
        // ... (Adicionar DbSet para Fornecedor, Entrada, Saida)
    }
}

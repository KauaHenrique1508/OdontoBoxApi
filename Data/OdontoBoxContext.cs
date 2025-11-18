
using Microsoft.EntityFrameworkCore;
using OdontoBoxApi.Models;

namespace OdontoBoxApi.Data;


public class OdontoBoxContext : DbContext
{

    public OdontoBoxContext(DbContextOptions<OdontoBoxContext> options) : base(options)
    {
    }

    public DbSet<Fornecedor> Fornecedores { get; set; }

    public DbSet<Produto> Produtos { get; set; }

    //public DbSet<Entrada> Entradas { get; set; }

    public DbSet<Saida> Saidas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Fornecedor n - n Produto
        modelBuilder.Entity<Produto>()
            .HasOne(p => p.Fornecedor)                    
            .WithMany(f => f.Produtos)                    
            .HasForeignKey(p => p.FornecedorId)           
            .OnDelete(DeleteBehavior.Restrict);           

        //Produto - Entrada
        // modelBuilder.Entity<Entrada>()
        //     .HasOne(e => e.Produto)                       
        //     .WithMany(p => p.Entradas)                    
        //     .HasForeignKey(e => e.ProdutoId)              
        //     .OnDelete(DeleteBehavior.Restrict);           

        //Fornecedor - Entrada
        // modelBuilder.Entity<Entrada>()
        //     .HasOne(e => e.Fornecedor)                   
        //     .WithMany(f => f.Entradas)                    
        //     .HasForeignKey(e => e.FornecedorId)           
        //     .OnDelete(DeleteBehavior.Restrict);           

        //Produto - Saída
        modelBuilder.Entity<Saida>()
            .HasOne(s => s.Produto)                       
            .WithMany(p => p.Saidas)                      
            .HasForeignKey(s => s.ProdutoId)              
            .OnDelete(DeleteBehavior.Restrict);          

        //Chave estrangeira de Produto
        modelBuilder.Entity<Produto>().HasIndex(p => p.FornecedorId);

        //Chave estrangeira de Entrada (Produto)
        // modelBuilder.Entity<Entrada>()
        //     .HasIndex(e => e.ProdutoId);

        //Chave estrangeira de Entrada (Fornecedor)
        // modelBuilder.Entity<Entrada>()
        //  .HasIndex(e => e.FornecedorId);

        //Chave estrangeira de Saída
        modelBuilder.Entity<Saida>().HasIndex(s => s.ProdutoId);


        // CNPJ único
        modelBuilder.Entity<Fornecedor>()
            .HasIndex(f => f.CNPJ)
            .IsUnique();

    }
}


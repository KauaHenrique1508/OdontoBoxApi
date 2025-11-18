using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OdontoBoxApi.Models;

public class Fornecedor
{
    [Key]
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string CNPJ { get; set; } = string.Empty;

    public string Telefone { get; set; } = string.Empty;

    public ICollection<Produto> Produtos { get; set; } = new List<Produto>();

    //public ICollection<Entrada> Entradas { get; set; } = new List<Entrada>();
}

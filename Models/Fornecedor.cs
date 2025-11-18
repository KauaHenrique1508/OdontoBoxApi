using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace OdontoBoxApi.Models;

public class Fornecedor
{

    [Key]
    public int Id { get; set; }


    [Required(ErrorMessage = "O nome do fornecedor é obrigatório.")]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 150 caracteres.")]
    public string Nome { get; set; } = string.Empty;


    [Required(ErrorMessage = "O CNPJ é obrigatório.")]
    [StringLength(18, MinimumLength = 14, ErrorMessage = "O CNPJ deve ter entre 14 e 18 caracteres.")]
    public string CNPJ { get; set; } = string.Empty;


    [Required(ErrorMessage = "O telefone é obrigatório.")]
    [StringLength(20, MinimumLength = 10, ErrorMessage = "O telefone deve ter entre 10 e 20 caracteres.")]
    public string Telefone { get; set; } = string.Empty;


    public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    public ICollection<Entrada> Entradas { get; set; } = new List<Entrada>();
}

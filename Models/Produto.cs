
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OdontoBoxApi.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? UnidadeMedida { get; set; }

        public decimal PrecoCusto { get; set; }

        public int QuantidadeAtual { get; set; }

        public int NivelMinimo { get; set; }
        public int FornecedorId { get; set; }
        [JsonIgnore]
        public Fornecedor? Fornecedor { get; set; }
        // public int SaidaId { get; set; }
        // public int EntradaId { get; set; }

        // public ICollection<Entrada> Entradas { get; set; } = new List<Entrada>();
        public ICollection<Saida> Saidas { get; set; } = new List<Saida>();
    }
}


using System.ComponentModel.DataAnnotations;

namespace OdontoBoxApi.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? UnidadeMedida { get; set; }

        public decimal PrecoCusto { get; set; }

        public int QuantidadeAtual { get; set; }

        public int NivelMinimo { get; set; }

        public int FornecedorId {get; set;}
        public Fornecedor? Fornecedor { get; set; }

        //public ICollection<Entrada> Entradas { get; set; } = new List<Entrada>();

        //public ICollection<Saida> Saidas { get; set; } = new List<Saida>();
    }
}

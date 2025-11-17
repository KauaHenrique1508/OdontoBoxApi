
using System.ComponentModel.DataAnnotations;

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
    }
}

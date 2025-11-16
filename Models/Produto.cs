
using System.ComponentModel.DataAnnotations;

namespace OdontoBoxApi.Models
{
    // Classe que representa o item de estoque (Produto)
    public class Produto
    {
        // Chave primária do produto
        [Key]
        public int Id { get; set; }

        public string? Nome { get; set; }

        // Unidade de medida (ex: "unidade", "caixa", "ml")
        public string? UnidadeMedida { get; set; }

        // Preço de custo unitário (para relatórios financeiros)
        public decimal PrecoCusto { get; set; }

        // Quantidade atual em estoque. Este campo é atualizado pelas Entradas e Saídas.
        public int QuantidadeAtual { get; set; }

        // Nível mínimo de estoque para disparar alertas (RN003)
        public int NivelMinimo { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace OdontoBoxApi.Models
{
    public class Saida
    {
        [Key]
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public string? DataSaida { get; set; }
        public int Quantidade { get; set; }
        public string? Motivo { get; set; }
        public string? Observacao { get; set; }
        public Produto? Produto { get; set; }
    }
}
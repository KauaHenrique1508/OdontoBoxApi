using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OdontoBoxApi.Models
{
    public class Saida
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataSaida { get; set; } = DateTime.Now;   
        public int Quantidade { get; set; }
        public string? Motivo { get; set; }
        public string? Observacao { get; set; }
        public int ProdutoId { get; set; }
        [JsonIgnore]
        public Produto? Produto { get; set; }

        // public ICollection<Produto> Produto { get; set; } = new List<Produto>();

    }
}
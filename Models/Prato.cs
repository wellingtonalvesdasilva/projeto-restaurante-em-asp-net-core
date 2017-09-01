using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Prato : EntityBase
    {
        [Required(ErrorMessage = "Nome do Prato é obrigatório")]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Restaurante é obrigatório")]
        [ForeignKey("Restaurante")]
        public long RestauranteId { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório")]
        public decimal Preco { get; set; }

        public virtual Restaurante Restaurante { get; set; }
    }
}

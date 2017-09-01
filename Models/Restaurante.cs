using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Restaurante : EntityBase
    {
        [Required(ErrorMessage = "Nome do Restaurante é obrigatório")]
        [StringLength(50)]
        public string Nome { get; set; }

        public virtual ICollection<Prato> Pratos { get; set; }
    }
}

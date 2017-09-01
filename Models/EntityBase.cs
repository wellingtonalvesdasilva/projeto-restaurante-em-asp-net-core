using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class EntityBase
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Data Hora Inserção obrigatória")]
        public DateTime DataHoraInsercao { get; set; }

        public DateTime? DataHoraAlteracao { get; set; }
    }
}

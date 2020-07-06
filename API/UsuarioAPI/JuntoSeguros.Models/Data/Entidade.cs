using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuntoSeguros.Models.Data
{
    public class Entidade
    {
        [Key]
        [NotMapped]
        public virtual int Id { get; set; }
    }
}

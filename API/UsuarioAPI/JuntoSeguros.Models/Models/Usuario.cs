
using JuntoSeguros.Models.Data;

namespace JuntoSeguros.Models.Models
{
    public class Usuario : Entidade
    {
        public int UsuarioId { get; set; }

        public string Login { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public string Funcao { get; set; }

        public string Email { get; set; }

        public override int Id
        {
            get
            {
                return UsuarioId;
            }
        }
    }
}

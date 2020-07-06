
namespace JuntoSeguros.Models.Dto
{
    public class UsuarioDto
    {
        public int? UsuarioId { get; set; }

        public string Login { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public string Funcao { get; set; }

        public string Email { get; set; }
    }
}

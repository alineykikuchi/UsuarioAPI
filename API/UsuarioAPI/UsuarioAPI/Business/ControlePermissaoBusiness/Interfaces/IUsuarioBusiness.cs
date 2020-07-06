
using JuntoSeguros.Models.Dto;
using JuntoSeguros.Models.Models;
using System.Collections.Generic;

namespace UsuarioAPI.ControlePermissaoBusiness.Interfaces
{
    public interface IUsuarioBusiness
    {
        Usuario CriarUsuario(UsuarioDto usuario);

        Usuario ConsultaUsuario(int usuarioId);

        IEnumerable<Usuario> ListaUsuarios();

        string AlterarUsuario(UsuarioDto usuario);

        string DeletarUsuario(UsuarioDto usuario);
    }
}

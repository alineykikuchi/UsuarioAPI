using JuntoSeguros.Models.Models;

namespace UsuarioAPI.LoginBusiness.Interfaces
{
    public interface ILoginBusiness
    {
        //string GenerateToken(Usuario usuario);

        Usuario EfetuarLogin(string senha, string login);
    }
}

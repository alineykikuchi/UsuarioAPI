using UsuarioAPI.LoginBusiness.Interfaces;
using JuntoSeguros.Models.Data;
using JuntoSeguros.Models.Models;
using System.Linq;

namespace UsuarioAPI.LoginBusiness
{
    public class LoginBusiness : ILoginBusiness
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        #region Constructor

        public LoginBusiness(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        #endregion

        
        public Usuario EfetuarLogin(string senha, string userName)
        {
            return _usuarioRepository.GetAll().FirstOrDefault(x => x.Senha == senha && x.Login == userName);
        }
    }
}

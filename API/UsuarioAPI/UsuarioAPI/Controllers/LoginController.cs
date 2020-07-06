
using JuntoSeguros.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsuarioAPI.ControlePermissaoBusiness.Interfaces;
using UsuarioAPI.LoginBusiness.Interfaces;
using UsuarioAPI.Services;

namespace UsuarioAPI.Controllers
{
    [Route("v1/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioBusiness _usuarioBusiness;
        private readonly ILoginBusiness _loginBusiness;

        public LoginController(IUsuarioBusiness usuarioBusiness, ILoginBusiness loginBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
            _loginBusiness = loginBusiness;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<dynamic> EfetuarLogin([FromBody]LoginDto model)
        {    
            var usuario = _loginBusiness.EfetuarLogin(model.Senha, model.UserName);

            if (usuario == null)
                return NotFound(new { message = "Usuário não encontrado" });

            var token = TokenService.GenerateToken(usuario);

            return new
            {
                Usuario = model,
                Token = token
            };
        }
        
    }
}

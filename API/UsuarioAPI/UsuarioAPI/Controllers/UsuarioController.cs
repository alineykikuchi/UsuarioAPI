using UsuarioAPI.ControlePermissaoBusiness.Interfaces;
using JuntoSeguros.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace UsuarioAPI.Controllers
{
    [Route("v1/usuarios")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

        #region Constructor

        public UsuarioController(IUsuarioBusiness loginBusiness)
        {
            _usuarioBusiness = loginBusiness;
        }

        #endregion

        [HttpGet("ListaUsuarios")]
        public IActionResult ConsultaListaUsuarios()
        {
            var lista = _usuarioBusiness.ListaUsuarios();
            return Ok(JsonConvert.SerializeObject(lista));
        }

        [HttpGet("Usuario/{id}")]
        public IActionResult ConsultaUsuario(int id)
        {
            var usuario = _usuarioBusiness.ConsultaUsuario(id);
            if (usuario == null)
                return NotFound();
            
            return new ObjectResult(usuario);
        }

        [HttpPost("InsereUsuario")]
        public IActionResult InsereUsuario([FromBody] UsuarioDto usuarioDto)
        {
            if (usuarioDto == null)
                return BadRequest();

            var usuario = _usuarioBusiness.CriarUsuario(usuarioDto);

            return Ok(JsonConvert.SerializeObject(usuario));
        }

        [HttpPost("AlteraUsuario")]
        public IActionResult AlteraUsuario([FromBody] UsuarioDto usuarioDto)
        {
            if (usuarioDto == null)
                return BadRequest();

            var retorno = _usuarioBusiness.AlterarUsuario(usuarioDto);

            return Ok(JsonConvert.SerializeObject(retorno));
        }

        [HttpPost("DeleteUsuario")]
        public IActionResult DeleteUsuario([FromBody] UsuarioDto usuarioDto)
        {
            if (usuarioDto == null)
                return BadRequest();
            
            var retorno = _usuarioBusiness.DeletarUsuario(usuarioDto);

            return Ok(JsonConvert.SerializeObject(retorno));
        }

    }
}

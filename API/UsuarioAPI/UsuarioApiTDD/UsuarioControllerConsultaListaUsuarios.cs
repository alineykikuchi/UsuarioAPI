using Microsoft.AspNetCore.Mvc;
using UsuarioAPI.Controllers;
using Xunit;

namespace UsuarioApiTDD
{
    public class UsuarioControllerConsultaListaUsuarios
    {
        [Fact]
        public void ConsultarUsuarios()
        {
            var controlador = new UsuarioController(Initialize.InicializarUsuarioBusiness());

            var retorno = controlador.ConsultaListaUsuarios();

            Assert.IsType<OkObjectResult>(retorno);
        }
    }
}

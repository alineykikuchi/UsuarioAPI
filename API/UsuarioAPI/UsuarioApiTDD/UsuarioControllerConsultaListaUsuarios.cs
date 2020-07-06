using JuntoSeguros.Models.ConfigurationSettings;
using JuntoSeguros.Models.Data;
using JuntoSeguros.Models.Dto;
using JuntoSeguros.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UsuarioAPI.ControlePermissaoBusiness;
using UsuarioAPI.ControlePermissaoBusiness.Interfaces;
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

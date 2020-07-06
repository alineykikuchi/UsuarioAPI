using JuntoSeguros.Models.ConfigurationSettings;
using JuntoSeguros.Models.Data;
using JuntoSeguros.Models.Dto;
using JuntoSeguros.Models.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json;
using System;
using UsuarioAPI.ControlePermissaoBusiness;
using UsuarioAPI.ControlePermissaoBusiness.Interfaces;
using UsuarioAPI.Controllers;
using Xunit;

namespace UsuarioApiTDD
{
    public class UsuarioControllerInsereUsuario 
    {
        
        [Fact]
        public void CadastroUsuarioComDadosObrigatorios()
        {
            var controlador = new UsuarioController(Initialize.InicializarUsuarioBusiness());
            var usuarioDto = new UsuarioDto
            {
                Login = "alinakikuchi",
                Nome = "João",
                Senha = "paodemel123",
                Funcao = "Funcionario",
                Email = "alina@teste.com"
            };

            var retorno = controlador.InsereUsuario(usuarioDto);

            Assert.IsType<OkObjectResult>(retorno);
            var usuario = (retorno as OkObjectResult).Value;
            var teste = JsonConvert.DeserializeObject<Usuario>(usuario.ToString());
            Assert.IsType<Usuario>(teste);
        }

        [Fact]
        public void LancarExecaoQuandoCamposStringsVazios()
        {
            var controlador = new UsuarioController(Initialize.InicializarUsuarioBusiness());

            var usuarioDto = new UsuarioDto();
            
            Assert.Throws<Exception>(() => controlador.InsereUsuario(usuarioDto));
        }
        

    }
}

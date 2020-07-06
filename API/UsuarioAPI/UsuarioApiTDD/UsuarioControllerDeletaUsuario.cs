using JuntoSeguros.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using UsuarioAPI.Controllers;
using Xunit;

namespace UsuarioApiTDD
{
    public class UsuarioControllerDeletaUsuario
    {
        [Fact]
        public void DeleteUsuarioComId()
        {
            var controlador = new UsuarioController(Initialize.InicializarUsuarioBusiness());
            var usuarioDto = new UsuarioDto
            {
                UsuarioId = 1,
                Login = "silva",
                Nome = "Maria Joaquina",
                Senha = "paodemel123",
                Funcao = "Funcionario",
                Email = "alina@teste.com"
            };

            var retorno = controlador.DeleteUsuario(usuarioDto);

            Assert.IsType<OkObjectResult>(retorno);
        }

        [Fact]
        public void DeleteUsuarioSemId()
        {
            var controlador = new UsuarioController(Initialize.InicializarUsuarioBusiness());
            var usuarioDto = new UsuarioDto
            {
                Login = "silva",
                Nome = "Maria Joaquina",
                Senha = "paodemel123",
                Funcao = "Funcionario",
                Email = "alina@teste.com"
            };
            
            Assert.Throws<Exception>(() => controlador.DeleteUsuario(usuarioDto));
        }
    }
}

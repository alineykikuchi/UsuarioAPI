using JuntoSeguros.Models.ConfigurationSettings;
using JuntoSeguros.Models.Data;
using JuntoSeguros.Models.Dto;
using JuntoSeguros.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using UsuarioAPI.ControlePermissaoBusiness;
using UsuarioAPI.ControlePermissaoBusiness.Interfaces;
using UsuarioAPI.Controllers;
using Xunit;

namespace UsuarioApiTDD
{
    public class UsuarioControllerAlteraUsuario
    {
        [Fact]
        public void AlteraUsuarioComDadosCorretos()
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

            var retorno = controlador.AlteraUsuario(usuarioDto);

            Assert.IsType<OkObjectResult>(retorno);
        }
    }
}

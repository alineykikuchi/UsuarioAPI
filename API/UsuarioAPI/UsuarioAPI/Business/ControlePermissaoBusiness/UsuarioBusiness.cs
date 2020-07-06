using UsuarioAPI.ControlePermissaoBusiness.Interfaces;
using JuntoSeguros.Models.Data;
using JuntoSeguros.Models.Dto;
using JuntoSeguros.Models.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace UsuarioAPI.ControlePermissaoBusiness
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        #region Constructor

        public UsuarioBusiness(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        #endregion



        public Usuario CriarUsuario(UsuarioDto usuarioDto)
        {
            var msgErro = ValidatedFields(usuarioDto);
            if (!string.IsNullOrEmpty(msgErro))
                throw new Exception(msgErro);

            usuarioDto.UsuarioId = null;
            var usuario = MapperDtoToModel(usuarioDto);
            
            return _usuarioRepository.Add(usuario);
        }

        public Usuario ConsultaUsuario(int usuarioId)
        {
            return _usuarioRepository.GetById(usuarioId);
        }

        public IEnumerable<Usuario> ListaUsuarios()
        {
            return _usuarioRepository.GetAll();
        }

        public string AlterarUsuario(UsuarioDto usuarioDto)
        {
            if (usuarioDto.UsuarioId == null)
                throw new Exception("Id não usuário não informado");

            var usuario = MapperDtoToModel(usuarioDto);
            _usuarioRepository.Update(usuario);

            return "Processamento realizado com sucesso.";
        }

        public string DeletarUsuario(UsuarioDto usuarioDto)
        {
            if (usuarioDto.UsuarioId == null)
                throw new Exception("Id não usuário não informado");

            var usuario = MapperDtoToModel(usuarioDto);
            _usuarioRepository.Remove(usuario);

            return "Processamento realizado com sucesso.";
        }

        #region Private Methods

        private string ValidatedFields(UsuarioDto usuarioDto)
        {
            foreach (PropertyInfo pi in usuarioDto.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string)pi.GetValue(usuarioDto);

                    if (string.IsNullOrEmpty(value))
                    {
                        return string.Format("Campo '{0}' não informado", pi.Name);
                    }
                }
            }
            return null;
        }

        private Usuario MapperDtoToModel(UsuarioDto usuarioDto)
        {
            var usuario = new Usuario();

            usuario.UsuarioId = usuarioDto.UsuarioId ?? 0;
            usuario.Login = usuarioDto.Login;
            usuario.Nome = usuarioDto.Nome;
            usuario.Senha = usuarioDto.Senha;
            usuario.Email = usuarioDto.Email;
            usuario.Funcao = usuarioDto.Funcao;

            return usuario;
        }
        
        #endregion

    }
}

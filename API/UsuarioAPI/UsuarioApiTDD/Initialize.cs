
using JuntoSeguros.Models.ConfigurationSettings;
using JuntoSeguros.Models.Data;
using JuntoSeguros.Models.Models;
using Microsoft.EntityFrameworkCore;
using UsuarioAPI.ControlePermissaoBusiness;
using UsuarioAPI.ControlePermissaoBusiness.Interfaces;

namespace UsuarioApiTDD
{
    public static class Initialize
    {
        public static IUsuarioBusiness InicializarUsuarioBusiness ()
        {
            var options = new DbContextOptionsBuilder<ConfigureModelsDbContext>()
                .UseSqlServer("Data Source=DESKTOP-KH5C1T2\\SQLEXPRESS01;Initial Catalog=USUARIOS;user id=sa;password=paodemel123;MultipleActiveResultSets=True;")
                .Options;

            var ctx = new ConfigureModelsDbContext(options);
            IRepository<Usuario> repo = new Repository<Usuario>(ctx);
            return new UsuarioBusiness(repo);
        }
    }
}

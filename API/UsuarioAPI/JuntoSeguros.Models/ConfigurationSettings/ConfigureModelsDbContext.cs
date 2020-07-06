using JuntoSeguros.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace JuntoSeguros.Models.ConfigurationSettings
{
    public class ConfigureModelsDbContext : DbContext
    {
        public ConfigureModelsDbContext(DbContextOptions<ConfigureModelsDbContext> options) : base(options)
        {

        }
        

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
using GerenciamentoDePessoas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePessoas.Data
{
    public class GerenciamentoDePessoasContext : IdentityDbContext<Usuario>
    {
        public GerenciamentoDePessoasContext(DbContextOptions<GerenciamentoDePessoasContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var administrador = new IdentityRole
            {
                Id = "1",
                Name = "administrador",
                NormalizedName = "ADMINISTRADOR"
            };

            var operador = new IdentityRole
            {
                Id = "2",
                Name = "operador",
                NormalizedName = "OPERADOR"
            };

            builder.Entity<IdentityRole>().HasData(administrador, operador);

            base.OnModelCreating(builder);
        }
    }
}

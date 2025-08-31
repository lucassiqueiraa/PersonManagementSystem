using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GerenciamentoDePessoas.Data;
using GerenciamentoDePessoas.Services;
using GerenciamentoDePessoas.Repository;
namespace GerenciamentoDePessoas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<GerenciamentoDePessoasContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("GerenciamentoDePessoasContext") ?? throw new InvalidOperationException("Connection string 'GerenciamentoDePessoasContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IPessoaService, PessoaService>();
            builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //Use routing
            app.UseRouting();

            app.UseAuthorization();

            // Define padrao das rotas
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

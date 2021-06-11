using CaixaTroco.Aplicacao.Interfaces;
using CaixaTroco.Aplicacao.Servicos;
using CaixaTroco.Dominio.Core.Interfaces.Repositorios;
using CaixaTroco.Dominio.Core.Interfaces.Servicos;
using CaixaTroco.Dominio.Servico.Servicos;
using CaixaTroco.Infraestrutura.Data;
using CaixaTroco.Infraestrutura.Data.Interfaces;
using CaixaTroco.Infraestrutura.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CaixaTroco
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();

            services.AddControllers();

            services.AddTransient<IServicoAplicacaoTroco, ServicoAplicacaoTroco>();
            services.AddTransient<IServicoAplicacaoTransacao, ServicoAplicacaoTransacao>();

            services.AddTransient<IServicoTransacao, ServicoTransacao>();
            services.AddTransient<IRepositorioTransacao, RepositorioTransacao>();

            services.AddTransient<IServicoCedula, ServicoCedula>();

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("Default"),
                    b => b.MigrationsAssembly("CaixaTroco.Api")
                )
            );

            services.AddTransient<IEFCoreDataService, EFCoreDataService>();
            services.AddSingleton<IDbDataService, DbDataService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CaixaTroco");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var dataservice = serviceProvider.GetRequiredService<IEFCoreDataService>();
            dataservice.InitializeDB(serviceProvider);
        }
    }
}

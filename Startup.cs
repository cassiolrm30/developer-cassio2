using API_Processos_Core.Models;
using API_Processos_Core.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API_Processos_Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Este método é chamado pelo tempo de execução para adicionar serviços ao container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<Contexto>(options => options.UseMySql(Configuration["Conexao:MySqlConnectionString"]));
            services.AddDbContext<Contexto>();  // Sem banco de dados
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ProcessoRepositorio>();     // Registrando o repositório
            services.AddCors(o => o.AddPolicy("MyPolicy", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // Este método é chamado pelo tempo de execução para configurar o pipeline de solicitação HTTP.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();
            app.UseHttpsRedirection();
            app.UseCors("MyPolicy");
            app.UseMvc();
        }
    }
}

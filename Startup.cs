using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CocontroladorAPI.DTOs;
using AutoMapper;

namespace CocontroladorAPI
{
    public class Startup
    {
        /*
        "Server=DESKTOP-HMU7HLM\\MSSQLSERVER01;Database=CocotecaPrueba;Integrated Security=True"                // Maic
        "Server=LAPTOP-UOPKI5AA\\MSSQLSERVER01;Database=CocotecaPrueba;Integrated Security=True"                // Nose
        */

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConfiguracionAutomapeo.Configurar();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
                services.AddControllersWithViews().AddNewtonsoftJson(opciones =>
                opciones.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<Models.CocotecaPruebaContext>(opciones =>
<<<<<<< HEAD
            opciones.UseSqlServer("Server=LAPTOP-UOPKI5AA\\MSSQLSERVER01;Database=Cocoteca;Integrated Security=True"));
=======
            opciones.UseSqlServer("Server=DESKTOP-HMU7HLM\\MSSQLSERVER01;Database=Cocoteca;Integrated Security=True" ));
>>>>>>> 067dd919b7ada83df3b4c24e42fbe545f12f4706
            //opciones.UseSqlServer("Server = DESKTOP-PCSQKMV; Database = CocotecaPrueba; User ID = neri; Password = Ajimin011100"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

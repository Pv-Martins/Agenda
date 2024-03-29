﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaITIX.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AgendaITIX
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            string connectionString = Configuration.GetConnectionString("Default");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<IDataService, DataService>();
            services.AddTransient<IConsultaRepository, ConsultaRepository>();
            services.AddTransient<IPacienteRepository, PacienteRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Consulta}/{action=Index}/{id?}");
            });

            serviceProvider.GetService<IDataService>().InicializaDB();
        }
    }
}

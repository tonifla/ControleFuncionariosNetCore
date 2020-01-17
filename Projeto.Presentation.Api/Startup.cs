﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Projeto.Presentation.Api
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
            #region Configuração para o SWAGGER

            services.AddSwaggerGen(
                swagger =>
                {
                    swagger.SwaggerDoc("v1",
                        new Info
                        {
                            Title = "Sistema de controle de funcionários",
                            Version = "v1",
                            Description = "Projeto desenvolvimento em aula - C# WebDeveloper",
                            Contact = new Contact
                            {
                                Name = "Coti Informática",
                                Url = "http://www.cotiinformatica.com.br",
                                Email = "contato@cotiinformatica.com.br"
                            }
                        });
                });

            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            #region Configuração para o SWAGGER

            app.UseSwagger(); //definindo o uso do Swagger para o projeto
            app.UseSwaggerUI(
                swagger =>
                {
                    swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto");
                }
                );

            #endregion
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LBHVerificationHubAPI.Helpers;
using LBHVerificationHubAPI.Interfaces;
using LBHVerificationHubAPI.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using LBHVerificationHubAPI.Infrastructure.V1.Services;
using LBHVerificationHubAPI.Infrastructure.V1.Middleware;
using System.Configuration;

namespace LBHVerificationHubAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ConfigurationSettings>(Configuration);
            var settings = Configuration.Get<ConfigurationSettings>();

            var connectionString = Environment.GetEnvironmentVariable("ConnectionString");

            services.ConfigureSearch(connectionString);



            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Token",
                    new ApiKeyScheme
                    {
                        In = "header",
                        Description = "Your Hackney API Key",
                        Name = "X-Api-Key",
                        Type = "apiKey"
                    });

                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    {"Token", Enumerable.Empty<string>()}
                });

                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "LBH Template API", Version = "v1" });

                c.DescribeAllEnumsAsStrings();

                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, @"LBHVerificationHubAPI.xml");
                c.IncludeXmlComments(filePath);
            });

            services.AddCustomServices();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Register exception handling middleware early so exceptions are handled and formatted
            app.UseMiddleware<CustomExceptionHandlerMiddleware>();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            // don't use preceding slash in endpoint path
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Hackney es API v1");
                c.RoutePrefix = "swagger";
            });

            //app.UseCors("AllowAny");

            app.UseMvc();
        }
    }
}

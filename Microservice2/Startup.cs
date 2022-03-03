using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore.Design;
using Microservice2.Ef;
using Microservice2.Domain.Managers.Interfaces;
using Microservice2.Domain.Managers.Implementation;
using Microservice2.Data.Interfaces;
using Microservice2.Data.Implementation;
using Microservice2.Domain.Aggregates.DebitCardAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using FluentValidation;
using Microservice2.Model.Dto;

namespace Microservice2
{
    public class Startup
    { 
        public Startup(IHostEnvironment env)
        {          
            var bulder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)           
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
              .AddEnvironmentVariables();
               Configuration = bulder.Build();
        }

        

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.ConfigureDbContext(Configuration);
            services.ConfigureAuthentication(Configuration);
            services.ConfigureBackendSwagger();
            services.ConfigureMapper();

            services.AddScoped<IDebitCardManager, DebitCardManager>();
            services.AddScoped<IDebitCardRepo, DebitCardRepo>();
            services.AddScoped<IDebitCardAggregateRepo, DebitCardAggregateRepo>();
            services.AddScoped<IUsersManager, UsersManager>();
            services.AddScoped<IUsersRepo, UsersRepo>();
            services.AddScoped<ILoginManager, LoginManager>();


            
         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Microservice2 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
           
        }
    }
}

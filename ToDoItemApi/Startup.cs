using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ToDoItemApi.Model.Configuration;
using ToDoItemApi.Services;


namespace ToDoItemApi
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
            var toDoListService = new ToDoListService(Configuration);
            services.AddSingleton<IToDoListService>(toDoListService);
            //if (Configuration.GetValue<bool>("Services:EnableCache"))
            //{
            //    services.AddSingleton<IToDoListService>(new CacheService(toDoListService));
            //}

            services.Configure<GetOptions>(Configuration.GetSection("GetOptions"));

            services.Configure<GetOptions>("SearchOptions", Configuration.GetSection("SearchOptions"));

            services.AddOptions<GetOptions>().Bind(Configuration.GetSection("GetOptions")).ValidateDataAnnotations();

            services.AddControllers();
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                var folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var xmlFiles = Directory.GetFiles(folder, "*.xml").ToList();
                xmlFiles.ForEach(x => c.IncludeXmlComments(x));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

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

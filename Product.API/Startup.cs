using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Product.Context;
using Product.Context.Interface;
using Product.Entities.Interface;
using Product.Repository;
using Product.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Product.API
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
            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters();

            services.AddTransient<IDatabaseContext, DatabaseContext>();
            services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(Configuration.GetConnectionString("ProductAPIDemo"), b => b.MigrationsAssembly("Product.API")));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "ProductAPIDocument",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Product API Document",
                        Version = "1"
                    });

                var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlFileFullPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                setupAction.IncludeXmlComments(xmlFileFullPath);
            });

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

            app.UseCors(builder => builder
            .AllowAnyOrigin());

            app.UseAuthorization();


            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint(
                    "/swagger/ProductAPIDocument/swagger.json",
                    "Product API Swagger Page"
                    );

                setupAction.RoutePrefix = "";  // Currently swagger is available at - http://localhost:5000/swagger/index.html, we want it on root.

            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

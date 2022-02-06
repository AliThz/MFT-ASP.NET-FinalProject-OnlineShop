using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopProject.WebApi
{
    public class Startup
    {
        #region [ - Ctor - ]
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region [ - Prop - ]
        public IConfiguration Configuration { get; }
        #endregion

        #region [ - ConfigureServices(IServiceCollection services) - ]
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region [ - AddMvcCore() - ]
            services.AddMvcCore().AddApiExplorer();
            #endregion

            #region [ - AddDbContext() - ]
            services.AddDbContextPool<EntityFrameworkCore.OnlineShopProjectDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("OrderFlowDebug03"));

            });
            #endregion

            #region [ - AddAutoMapper() - ]
            services.AddAutoMapper(typeof(Startup));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Application.Profiles.AutoMapperProfile());
            }).CreateMapper();

            services.AddSingleton(mappingConfig);

            #endregion

            #region [ - AddControllers() - ]
            services.AddControllers();
            #endregion

            #region [ - AddSwaggerDocument() - ]

            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Online Shop API";
                    document.Info.Description = "Online Shop";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = "https://twitter.com/spboyer"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    };
                };
            });

            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnlineShopProject.WebApi", Version = "v1" });
            });

            services.AddServicesOfAllTypes();
            services.AddServicesWithAttributeOfType<ScopedServiceAttribute>();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("EnablesCors", builder =>
            //    {
            //        builder.WithOrigins("http://localhost:8080")
            //        .AllowAnyHeader()
            //        .AllowAnyMethod()
            //        .Build();
            //    });
            //});
        }
        #endregion

        #region [ - Configure(IApplicationBuilder app, IWebHostEnvironment env) - ]
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseOpenApi();
                app.UseSwaggerUi3();
                app.UseDeveloperExceptionPage();

                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnlineShopProject.WebApi v1"));
                //app.UseSwagger();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseCors("EnablesCors");
        } 
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Demo.Models;
using Demo.Services.Implementation;
using Demo.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Demo.Common;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;

namespace Demo {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddControllersWithViews ( );

            // using Microsoft.EntityFrameworkCore;
            services.AddDbContext<UserContext> (options =>
                options.UseSqlServer ("Data Source=SDNMS-KARANP\\SQLEXPRESS;Initial Catalog=Assignment_DotNetCoreMVC;MultipleActiveResultSets=True;User Id=karanp;Password=Password@kp01"));

            services.AddScoped<IUserService, UserService> ( );
            

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration (mc => {
                mc.AddProfile (new MappingProfile ( ));
            });

            IMapper mapper = mappingConfig.CreateMapper ( );
            services.AddSingleton (mapper);

            services.AddRazorPages();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Recepi CRUD", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ( )) {
                app.UseDeveloperExceptionPage ( );
            } else {
                app.UseExceptionHandler ("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ( );
            }
            app.UseHttpsRedirection ( );
            app.UseStaticFiles ( );

            app.UseRouting ( );

            app.UseEndpoints (endpoints => {
                endpoints.MapControllerRoute (
                    name: "default",
                    pattern: "{controller=User}/{action=GetUsers}/{id?}");
            });

            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "RecepiCRUD");
            });
        }
    }
}
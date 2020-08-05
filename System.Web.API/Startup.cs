using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace System.Web.API
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
            services.AddSwaggerGen(a =>
            {
                a.EnableAnnotations();
                a.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My Workplace APIs",
                    Version = "v1",
                    Description = "It must be a GDS System but used to be my test actions.",
                    TermsOfService = new Uri("https://api.eniacgds.com/"),
                    Contact = new OpenApiContact()
                    {
                        Name = "Sajad Ramezani", Email = "s.ramezani@enb.ir", Url = new Uri("https://linkedin.com")
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "GDS Api LICX"
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                a.IncludeXmlComments(xmlPath);
            });
            services.AddControllers();
            services.AddDbContext<DataAccessLayer.Entities>();
            services.AddScoped(typeof(Services.Repositories.IBaseRepository<>), typeof(Services.Repositories.BaseRepository<>));
            services.AddScoped<Services.Repositories.IUnitOfWork, Services.Repositories.UnitOfWork>();
            services.AddScoped<Services.Repositories.IFileRepository, Services.Repositories.FileRepository>();
            services.AddScoped<Services.Repositories.IUserRepositories, Services.Repositories.UserRepositories>();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("Secret").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(a =>
            {
                a.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}

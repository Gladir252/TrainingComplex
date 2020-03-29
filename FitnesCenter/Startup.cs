using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FitnesCenter.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using FitnesCenter.BusinessModels;
using FitnesCenter.Services;
using FitnesCenter.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.Swagger;
using Microsoft.OpenApi.Models;

namespace FitnesCenter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUser, UserService>();
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:50133",
                                        "http://localhost:4200")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });


            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer",
                        new OpenApiSecurityScheme
                        {
                            In = ParameterLocation.Header,
                            Description = "Please enter into field the word 'Bearer' following by space and JWT",
                            Name = "Authorization",
                            Type = SecuritySchemeType.ApiKey
                        });

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1.0.0",
                    Title = $"v1 API",
                    Description = "v1 API",
                    TermsOfService = new Uri("https://www.c-sharpcorner.com/members/catcher-wong"),
                    Contact = new OpenApiContact
                    {
                        Name = "Catcher Wong",
                        Email = "catcher_hwq@outlook.com",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Apache-2.0",
                        Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                    }
                });
            });


            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "You api title", Version = "v1" });
            //    c.AddSecurityDefinition("Bearer",
            //        new ApiKeyScheme
            //        {
            //            In = "header",
            //            Description = "Please enter into field the word 'Bearer' following by space and JWT",
            //            Name = "Authorization",
            //            Type = "apiKey"
            //        });
            //    c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
            //        { "Bearer", Enumerable.Empty<string>() },
            //    });

            //});



            //services.AddDefaultIdentity<User>().AddRoles<Role>();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;////
                options.SaveToken = true;/////
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,//
                    ValidateAudience = false,//
                    ValidateLifetime = true,//
                    ValidateIssuerSigningKey = true,


                    ValidIssuer = "http://localhost:50133",
                    ValidAudience = "http://localhost:50133",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtCreater.SECRET_KEY))
                };

            });

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TrComDBContext>(options => options.UseSqlServer(connection));

            //services.RegisterRepositories();
            //services.RegisterServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Northwind Service API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); 
            });
        }
    }
}

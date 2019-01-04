using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PcPartPickerBackendAPI.Repository;
using PcPartPickerBackendAPI.Repository.Interfaces;
using PcPartPickerBackendAPI.ViewModels;
using PcPartPickerBackendAPI.Models;
using PcPartPickerBackendAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using PcPartPickerBackendAPI.Helpers;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace PcPartPickerBackendAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddJsonOptions(options => {
                options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            });
            services.AddAutoMapper();

            services.AddSingleton<IConfiguration>(Configuration);

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddTransient<IPriceRepository, PriceRepository>();
            services.AddTransient<IPartRepository, PartRepository>();
            services.AddTransient<IRepository<Part>, PartRepository>();
            services.AddTransient<IRepository<Cpu>, CpuRepository>();
            services.AddTransient<IBuildRepository, BuildRepository>();
            services.AddTransient<IRepository<Build>, BuildRepository>();
            services.AddTransient<IRepository<Gpu>, GpuRepository>();
            services.AddTransient<IRepository<Memory>, MemoryRepository>();
            services.AddTransient<IRepository<Motherboard>, MotherboardRepository>();
            services.AddTransient<IRepository<Pccase>, PccaseRepository>();
            services.AddTransient<IRepository<Storage>, StorageRepository>();
            services.AddTransient<IRepository<Powersupply>, PowersupplyRepository>();
            services.AddTransient<IRepository<PartViewModel>, CpuRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseDefaultFiles();
            app.UseStaticFiles();
            
            app.UseHttpsRedirection();
            app.UseCors(builder => 
                builder
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod()
            );
            app.UseMvc();
        }
    }
}



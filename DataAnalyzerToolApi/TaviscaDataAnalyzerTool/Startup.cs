using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TaviscaDataAnalyzerDatabase;
using TaviscaDataAnalyzerServiceProvider;
using TaviscaDataAnalyzerCache;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using TaviscaDataAnalyzerTranslator.AirTranslator;
using TaviscaDataAnalyzerTranslator.HotelsTranslator;

namespace TaviscaDataAnalyzerTool
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.Configure<AppSetting>(Configuration.GetSection("AppSetting"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton(Configuration);
               
            services.AddTransient<IHotelTranslator, HotelTranslator>();
            services.AddTransient<IAirTranslator,AirTranslator >();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ISqlConnector, SqlConnector>();
            services.AddTransient<IHotelRepository, HotelSqlDatabase>(); 
            services.AddTransient<IAirWebApiService, AirWebApiService>();
            services.AddTransient<ICache, RedisCache>();
            services.AddTransient<IRedisConnectionFactory, RedisConnectionFactory>();
            services.AddTransient<IAirRepository, AirSqlDatabase>();
            services.AddTransient<IHotelWebApiServiceProvider, HotelWebApiServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("MyPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.ConfigureExceptionHandler();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

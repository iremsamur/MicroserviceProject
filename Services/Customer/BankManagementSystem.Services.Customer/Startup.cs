using BankManagementSystem.Services.Customer.Services.Abstract;
using BankManagementSystem.Services.Customer.Services.Concrete;
using BankManagementSystem.Services.Customer.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Services.Customer
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
            //dependency injection i?in soyut ve somut servis s?n?f e?le?tirmesini yaz?yoruz
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerAccountService, CustomerAccountService>();
            //automapper konfig?rasyonu
            services.AddAutoMapper(typeof(Startup));

            services.Configure<DatabaseSettings>(Configuration.GetSection("DatabaseSettings"));//veritaban? ba?lant? bilgilerini yazd???m?z DatabaseSettings key de?eri
            //IDatabaseSettings i?indeki ba?lant? i?in DatabaseSettings.value ile onun de?erlerini al?yoruz
            services.AddSingleton<IDatabaseSettings>(sp =>
            {
                return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;

            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BankManagementSystem.Services.Customer", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BankManagementSystem.Services.Customer v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

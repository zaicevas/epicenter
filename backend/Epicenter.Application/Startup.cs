using Epicenter.Domain.Abstract;
using Epicenter.Domain.Models;
using Epicenter.Domain.Services;
using Epicenter.Infrastructure;
using Epicenter.Infrastructure.Debugging;
using Epicenter.Infrastructure.Debugging.Abstract;
using Epicenter.Persistence.Mappers;
using Epicenter.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Epicenter.Application
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            // these are injected by default (from Program.cs)
            Configuration = configuration;
            HostingEnvironment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            AppSettings config = new AppSettings();
            Configuration.GetSection("AppSettings").Bind(config);
            services.AddSingleton(config);
            services.AddScoped<PlateService>();
            services.AddScoped<FaceService>();
            services.AddScoped<FaceAPIService>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPlateRepository, PlateRepository>();
            services.AddScoped<ITimestampRepository, TimestampRepository>();
            services.AddScoped<Mapper<Person>>();
            services.AddScoped<Mapper<Plate>>();
            services.AddScoped<Mapper<Timestamp>>();
            services.AddScoped<ILogger, FileLogger>(logger => new FileLogger($"Logs/log_{Environment.TickCount.ToString()}.log"));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
}

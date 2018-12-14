using Epicenter.Persistence.DbContexts;
using Epicenter.Domain.Abstract;
using Epicenter.Domain.Services;
using Epicenter.Infrastructure;
using Epicenter.Infrastructure.Debugging;
using Epicenter.Infrastructure.Debugging.Abstract;
using Epicenter.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Epicenter.Application.Controllers.Delegates;

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
            services.AddScoped<RecognitionDelegate>();
            services.AddScoped<TimestampService>();
            services.AddScoped<BaseImageService>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPlateRepository, PlateRepository>();
            services.AddScoped<ITimestampRepository, TimestampRepository>();
            services.AddScoped<ILogger, FileLogger>(logger => new FileLogger($"Logs/log_{Environment.TickCount.ToString()}.log"));
            services.AddDbContext<EpicenterDbContext>(options => options.UseSqlServer(AppSettings.Configuration.ConnectionString));
            services.AddMvc(options =>
            {
                options.AllowEmptyInputInBodyModelBinding = true;
            });
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

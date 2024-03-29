﻿using MediatR;
using ProductRegistry.Api.Configurations.Api;
using ProductRegistry.Api.Configurations.Swagger;
using ProductRegistry.Infrastructure.CrossCutting.IoC;

namespace ProductRegistry.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddRazorPages();

            services.AddHttpContextAccessor();

            services.RegisterServices();

            services.AddAutoMapperSetup();

            services.ConfigureStatupApi(Configuration);

            services.AddMediatR(typeof(Startup));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseApiConfiguration(env);
        }
    }
}

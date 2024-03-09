using MediatR;
using ProductRegistry.Api.Configurations.Api;
using ProductRegistry.Api.Configurations.Swagger;

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

            services.AddSwaggerDocumentation(Configuration);

            services.AddRazorPages();


            services.ConfigureStatupApi(Configuration);

            services.AddMediatR(typeof(Startup));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseApiConfiguration(env);
        }
    }
}

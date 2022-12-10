using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace APIUdemy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Metodo ConfigureServices para usar los servicios
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Configuracion del Connection string, va a ir dentro de AplicationDbContext..
            services.AddDbContext<AplicationDbContext>(options =>
                //options.UseSqlServer() indicando que es sql server..
                //Dentro de esta funcion Configuration.GetConnectionString y ahora si dentro..
                //El connection string, el cual esta configurado en appsettings.Development.json
                options.UseSqlServer(Configuration.GetConnectionString("defaultConnection"))
            );

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIAutores", Version = "v1" });
            });
        }

        // Metodo Configure para usar en middlewares
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIAutores v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}


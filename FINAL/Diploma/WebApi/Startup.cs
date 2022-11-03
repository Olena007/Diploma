using Application.Interfaces;
using Application.Providers;
using Application.Services;
using Persistence;
using Persistence.Context;
using System.Text.Json.Serialization;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CORSPolicy",
                    builder =>
                    {
                        builder
                        .WithOrigins(new [] { "http://localhost:3000", "http://localhost:8080", "http://localhost:1433"  })
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


            services.AddSwaggerGen();
            
            services.AddPersistence(Configuration);
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddScoped<IPhoneProvider, PhoneProvider>();
            services.AddScoped<IComputerProvider, ComputerProvider>();
            services.AddScoped<IClientProvider, ClientProvider>();
            services.AddScoped<JwtService>();
            services.AddScoped<IBasketProvider, BasketProvider>();
            services.AddScoped<IHistoryProvider, HistoryProvider>();
            services.AddScoped<IBasketCompProvider, BasketCompProvider>();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("CORSPolicy");

            //app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Diploma");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

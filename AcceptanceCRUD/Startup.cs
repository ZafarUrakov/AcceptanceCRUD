using AcceptanceCRUD.Brokers.Storages;
using AcceptanceCRUD.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AcceptanceCRUD
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<StorageBroker>();
            AddBrokers(services);
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    name: "v1",
                    info: new OpenApiInfo
                    {
                        Title = "AcceptanceCRUD",
                        Version = "v1"
                    }
                );
            });
        }

        public static void Configure(
            IApplicationBuilder applicationBuilder,
            IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.IsDevelopment())
            {
                applicationBuilder.UseDeveloperExceptionPage();
                applicationBuilder.UseSwagger();
                applicationBuilder.UseSwaggerUI(options =>

                options.SwaggerEndpoint(
                    url: "/swagger/v1/swagger.json",
                    name: "AcceptanceCRUD v1"));
            }

            applicationBuilder.UseHttpsRedirection();
            applicationBuilder.UseRouting();
            applicationBuilder.UseAuthorization();
            applicationBuilder.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        private static void AddBrokers(IServiceCollection services)
        {
            services.AddScoped<IStorageBroker, StorageBroker>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}

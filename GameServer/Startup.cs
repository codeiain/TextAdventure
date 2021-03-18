using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using GameServer.Models;
using GameServer.Models.Settings;
using GameServer.Services;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace GameServer
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
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddOptions();
            services.Configure<AppSettings>(configuration.GetSection("App"));
            var mongoConnectionString = configuration.GetSection("App:MongoSettings:ConnectionString").Value.Replace("{DB_NAME}",configuration.GetSection("App:MongoSettings:DatabaseName").Value);
            var redisConnectionString = configuration.GetSection("App:RedisSettings:ConnectionString").Value;
            
            services.AddSingleton<IRepository<GameModel>, MongoDbRepository<GameModel>>();
            services.AddSingleton<IRepository<GameStateModel>, MongoDbRepository<GameStateModel>>();
            services.AddSingleton<IGameStateService, GameStateService>();
            services.AddSingleton<IGameService, GameService>();
            
            services.AddControllers();
            services.AddHealthChecks()
                .AddMongoDb(mongodbConnectionString: mongoConnectionString,
                    name: "MongoDB",
                    failureStatus: HealthStatus.Unhealthy)
                .AddRedis(redisConnectionString, "Redis", HealthStatus.Unhealthy);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "GameServer", Version = "v1"});
            });
            services.AddHealthChecksUI(opt =>
                {
                    opt.SetEvaluationTimeInSeconds(15); //time in seconds between check
                    opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks
                    opt.SetApiMaxActiveRequests(1); //api requests concurrency
                
                    opt.AddHealthCheckEndpoint("GameServer", "/healthz"); //map health check api
                    opt.AddHealthCheckEndpoint("ClientServer", configuration.GetSection("App:WebApis:ClientServer").Value);
                    opt.AddHealthCheckEndpoint("ChatServer", configuration.GetSection("App:WebApis:ChatServer").Value);
                })
                .AddInMemoryStorage();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GameServer v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //adding endpoint of health check for the health check ui in UI format
                endpoints.MapHealthChecks("/healthz", new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

                //map healthcheck ui endpoing - default is /healthchecks-ui/
                endpoints.MapHealthChecksUI();
                
            });
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseHealthChecks("/healthcheck");
            
            app.UseHealthChecks("/hc",
                new HealthCheckOptions
                {
                    ResponseWriter = async (context, report) =>
                    {
                        var result = JsonConvert.SerializeObject(
                            new
                            {
                                status = report.Status.ToString(),
                                errors = report.Entries.Select(e => new
                                    {key = e.Key, value = Enum.GetName(typeof(HealthStatus), e.Value.Status)})
                            });
                        context.Response.ContentType = MediaTypeNames.Application.Json;
                        await context.Response.WriteAsync(result);
                    }
                });
            app.UseMvcWithDefaultRoute();
        }
    }
}
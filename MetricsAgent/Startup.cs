using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using MetricsAgent.DAL;
using AutoMapper;
using Quartz.Spi;
using Quartz;
using Quartz.Impl;
using MetricsAgent.Jobs;
using System.IO;
using System.Reflection;

namespace MetricsAgent
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
            ConfigureSqlLiteConnection(services);
            services.AddControllers();

            services.AddSingleton(new MapperConfiguration(mapperProfile => mapperProfile.AddProfile(new MapperProfile())).CreateMapper());

            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            services.AddSingleton<CpuMetricsJob>();
            services.AddSingleton(new JobSchedule(jobType: typeof(CpuMetricsJob), cronExpression: "0/5 * * * * ?"));

            services.AddSingleton<RamMetricsJob>();
            services.AddSingleton(new JobSchedule(jobType: typeof(RamMetricsJob), cronExpression: "0/5 * * * * ?"));

            services.AddSingleton<HddMetricsJob>();
            services.AddSingleton(new JobSchedule(jobType: typeof(HddMetricsJob), cronExpression: "0/5 * * * * ?"));

            services.AddSingleton<DotNetMetricsJob>();
            services.AddSingleton(new JobSchedule(jobType: typeof(DotNetMetricsJob), cronExpression: "0/5 * * * * ?"));

            services.AddSingleton<NetworkMetricsJob>();
            services.AddSingleton(new JobSchedule(jobType: typeof(NetworkMetricsJob), cronExpression: "0/5 * * * * ?"));

            services.AddHostedService<QuartzHostedService>();

            services.AddSingleton<ICpuMetricsRepository, CpuMetricsRepository>();
            services.AddSingleton<IDotNetMetricsRepository, DotNetMetricsRepository>();
            services.AddSingleton<IHddMetricsRepository, HddMetricsRepository>();
            services.AddSingleton<INetworkMetricsRepository, NetworkMetricsRepository>();
            services.AddSingleton<IRamMetricsRepository, RamMetricsRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MetricsAgent", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        private void ConfigureSqlLiteConnection(IServiceCollection services)
        {
            const string connectionString = "Data Source = metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
            if (IsDataBaseExist(connectionString))
            {
                return;
            }
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            PrepareSchema(connection);
        }
        
        private bool IsDataBaseExist(string connectionString)
        {
            string dbName;
            string[] strings = connectionString.Split(';');

            foreach (var item in strings)
            {
                if (item.StartsWith("data ", StringComparison.OrdinalIgnoreCase) && 
                    item.Contains("source", StringComparison.OrdinalIgnoreCase) && 
                    item.Contains('='))
                {
                    dbName = item.Split('=')[^1];
                    dbName = dbName.Trim();
                    if (File.Exists(dbName))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void PrepareSchema(SQLiteConnection connection)
        {
            using (var cmd = new SQLiteCommand(connection))
            {
                //cmd.CommandText = "DROP TABLE IF EXISTS cpumetrics";
                //cmd.ExecuteNonQuery();
                //cmd.CommandText = "DROP TABLE IF EXISTS hddmetrics";
                //cmd.ExecuteNonQuery();
                //cmd.CommandText = "DROP TABLE IF EXISTS dotnetmetrics";
                //cmd.ExecuteNonQuery();
                //cmd.CommandText = "DROP TABLE IF EXISTS networkmetrics";
                //cmd.ExecuteNonQuery();
                //cmd.CommandText = "DROP TABLE IF EXISTS rammetrics";
                //cmd.ExecuteNonQuery();

                cmd.CommandText = @"CREATE TABLE cpumetrics(id INTEGER PRIMARY KEY, value INT, time TEXT)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"CREATE TABLE hddmetrics(id INTEGER PRIMARY KEY, value INT, time TEXT)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"CREATE TABLE dotnetmetrics(id INTEGER PRIMARY KEY, value INT, time TEXT)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"CREATE TABLE networkmetrics(id INTEGER PRIMARY KEY, value INT, time TEXT)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"CREATE TABLE rammetrics(id INTEGER PRIMARY KEY, value INT, time TEXT)";
                cmd.ExecuteNonQuery();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MetricsAgent v1"));
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

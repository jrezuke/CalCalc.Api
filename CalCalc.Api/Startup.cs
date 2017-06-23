using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CalCalc.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CalCalc.Api
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
            services.AddCors(opt =>
                {
                    var origins = new string[] { "http://localhost:4200", "http://localhost:6702" };
                    opt.AddPolicy("myPolicy", builder =>
                    builder.WithOrigins(origins).AllowAnyHeader().AllowAnyMethod());
                });

            services.AddMvc();
            var connStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CalCalcDbContext>(
                options => options.UseSqlServer(connStr, 
                b => b.MigrationsAssembly("CalCalc.Api"))
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors("myPolicy");
            app.UseMvc();
        }
    }
}

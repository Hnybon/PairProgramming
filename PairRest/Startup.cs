﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace PairRest
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors();
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowSpecificOrigin", builder => builder.WithOrigins("http://example.com", "http://185.20.241.83:3000").AllowAnyHeader().AllowAnyMethod());
            //    options.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin());
            //    options.AddPolicy("AllowAnyOriginGetPost",
            //        builder => builder.AllowAnyOrigin().WithMethods("GET", "POST"));
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => { options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }); // allow everything from anywhere});

            app.UseMvc();
        }
    }
}

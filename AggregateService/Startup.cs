using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AggregateService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MicroServiceCore.HttpClientConsul;
using MicroServiceCore.HttpClientPolly;
using MicroServiceCore.Registry.Extentions;
using System.Net.Http;

namespace AggregateService {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            services.AddHttpClient ().AddHttpClientConsul<ConsulHttpClient> ();
            services.AddSingleton<ITeamServiceClient, HttpTeamServiceClient> ();
            services.AddControllers ();

       
            //这个地方的micro是重点，名字不对polly不会生效
            services.AddPollyHttpClient ("micro", x => { x.CircuitBreakerDownTime = 30; x.CircuitBreakerOpenFallCount = 2; x.RetryCount = 3; x.TimeoutTime = 60; x.httpResponseMessage= new HttpResponseMessage
            {
                Content = new StringContent("自定义异常"),
                StatusCode = System.Net.HttpStatusCode.GatewayTimeout
            };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            //   app.UseHttpsRedirection();

            app.UseRouting ();

            app.UseAuthorization ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}
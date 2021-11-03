using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MicrosoftServiceCore.Cluster;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicrosoftServiceCore.Registry.Extentions
{
    /// <summary>
    /// Console 注册中心扩展(加载配置)
    /// </summary>
    public static class MicroServiceConsulServiceCollectionExtensions
    {
        // consul服务注册
        public static IServiceCollection AddConsulRegistry(this IServiceCollection services, IConfiguration configuration)
        {
            // 1、加载Consul服务注册配置
          
            services.Configure<ServiceRegistryConfig>(configuration.GetSection("ConsulRegistry"));
          //  services.Configure<ServiceRegistryConfig>("",x=>{x.Address="";});

            // 2、注册consul注册
            services.AddSingleton<IServiceRegistry, ConsulServiceRegistry>();
            return services;
        }

        // consul服务发现
        public static IServiceCollection AddConsulDiscovery(this IServiceCollection services)
        {
            // 1、加载Consul服务发现配置
           // services.Configure<ServiceDiscoveryConfig>(configuration.GetSection("ConsulDiscovery"));

            // 2、注册consul服务发现
            services.AddSingleton<IServiceDiscovery, ConsulServiceDiscovery>();
            return services;
        }




        /// <summary>
        /// 添加consulClient
        /// </summary>
        /// <typeparam name="ConsulHttpClient"></typeparam>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IServiceCollection AddHttpClientConsul<ConsulHttpClient>(this IServiceCollection services) where ConsulHttpClient : class
        {
            // 1、注册consul
            services.AddConsulDiscovery();

            // 2、注册服务负载均衡
            services.AddSingleton<ILoadBalance, RandomLoadBalance>();

            // 3、注册httpclient
            services.AddSingleton<ConsulHttpClient>();

            return services;
         }



    }
}

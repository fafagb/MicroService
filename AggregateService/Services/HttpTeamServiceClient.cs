
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AggregateService.Models;
using MicrosoftServiceCore.HttpClientConsul;
using Newtonsoft.Json;

namespace AggregateService.Services
{
    /// <summary>
    /// 服务调用实现
    /// </summary>
    public class HttpTeamServiceClient : ITeamServiceClient
    {
        /*public readonly IServiceDiscovery serviceDiscovery;
        public readonly ILoadBalance loadBalance;*/
        private readonly IHttpClientFactory httpClientFactory;
        private readonly string ServiceSchme = "https";
        private readonly string ServiceName = "teamservice"; //服务名称
        private readonly string ServiceLink = "/Teams"; //服务名称
        private readonly ConsulHttpClient consulHttpClient;
        public HttpTeamServiceClient(/*IServiceDiscovery serviceDiscovery, 
                                    ILoadBalance loadBalance,*/
                                    IHttpClientFactory httpClientFactory,
                                    ConsulHttpClient consulHttpClient)
        {
            /*this.serviceDiscovery = serviceDiscovery;
            this.loadBalance = loadBalance;*/
            this.httpClientFactory = httpClientFactory;
            this.consulHttpClient = consulHttpClient;
        }

        public async Task<IList<Team>> GetTeams()
        {
            // 1、获取服务
            /* IList<ServiceUrl> serviceUrls = await serviceDiscovery.Discovery(ServiceName);

             // 2、负载均衡服务
             ServiceUrl serviceUrl = loadBalance.Select(serviceUrls);

             // string name = "https://localhost:5001";*/

            // 3、建立请求
            // for (int i =0;i < 100;i++)
            // {
            //     try
            //     {
            //         Thread.Sleep(1000);
            //         HttpClient httpClient = httpClientFactory.CreateClient("mrico");
            //         HttpResponseMessage response = await httpClient.GetAsync("https://localhost:5001" + ServiceLink);

            //         // 3.1json转换成对象
            //         IList<Team> teams = null;
            //         if (response.StatusCode == HttpStatusCode.OK)
            //         {
            //             string json = await response.Content.ReadAsStringAsync();

            //             teams = JsonConvert.DeserializeObject<List<Team>>(json);
            //         } else
            //         {
            //             Console.WriteLine($"降级处理：{await response.Content.ReadAsStringAsync()}");
            //         }
            //     }
            //     catch (Exception e)
            //     {
            //         Console.WriteLine($"异常捕获：{e.Message}");
            //     }
                
            // }
            
          List<Team> teams = await consulHttpClient.GetAsync<List<Team>>(ServiceSchme, ServiceName, ServiceLink);

            return teams;
        }

       

    }
}

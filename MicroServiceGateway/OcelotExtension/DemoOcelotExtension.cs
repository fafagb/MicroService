using Ocelot.Middleware.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceGateway.OcelotExtension
{
    /// <summary>
    /// 注册ocelot中间件
    /// </summary>
    public static class DemoOcelotExtension
    {
        public static IOcelotPipelineBuilder UseDemoResponseMiddleware(this IOcelotPipelineBuilder builder)
        {
            return builder.UseMiddleware<DemoResponseMiddleware>();
        }
    }
}

using System;

namespace MicrosoftServiceCore.Registry {
    public interface IServiceRegistry {
        /// <summary>
        /// 注册服务
        /// </summary>
        void Register (ServiceRegistryConfig serviceNode);

        /// <summary>
        /// 撤销服务
        /// </summary>
        void Deregister (ServiceRegistryConfig serviceNode);
    }

}
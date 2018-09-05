using Acw.Core.System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Acw.Core.Acw.Modularity
{
    public class ServiceConfigurationContext
    {
        public IServiceCollection Services { get; }
      
        public IDictionary<string, object> Items { get; }
        /// <summary>
        /// 获取/设置可以在存储期间存储的任意命名对象
        /// 服务注册阶段和模块之间的共享。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[string key]
        {
            get => Items.GetOrDefault(key);
            set => Items[key] = value;
        }
        public ServiceConfigurationContext([NotNull] IServiceCollection services)
        {
            Services = Check.NotNull(services, nameof(services));
            Items = new Dictionary<string, object>();
        }
    }
}
